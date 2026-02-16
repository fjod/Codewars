package main

import (
	"errors"
	"fmt"
	"math/rand"
	"sync"
	"time"
)

type CircuitBreakerState int

// Declare constants with iota
const (
	Closed CircuitBreakerState = iota
	Open
	HalfOpen
)

type WebFunc func() (t any, e error)

var (
	ErrOpen = errors.New("cb is Open")
)

type CircuitBreaker struct {
	state          CircuitBreakerState
	errAmount      int
	errPropagation chan struct{}
	closeChan      chan struct{}
	mu             sync.RWMutex
}

func NewCircuitBreaker() *CircuitBreaker {
	cb := &CircuitBreaker{
		state:          Closed,
		errAmount:      0,
		errPropagation: make(chan struct{}, 5),
		closeChan:      make(chan struct{}),
		mu:             sync.RWMutex{},
	}
	go func() {
		for {
			select {
			case <-cb.closeChan:
				return
			case <-cb.errPropagation:
				cb.mu.Lock()
				cb.errAmount++
				if cb.state == HalfOpen {
					fmt.Printf("error on half-open, switching to open\n")
					cb.errAmount = 0
					cb.state = Open
					cb.mu.Unlock()
					go func() {
						time.Sleep(5 * time.Second)
						cb.mu.Lock()
						cb.state = HalfOpen
						cb.mu.Unlock()
						fmt.Printf("slept for 5 sec, switching to half open\n")
					}()
				} else if cb.errAmount >= 5 && cb.state == Closed {
					fmt.Printf("too much errors in closed state, switching to open\n")
					cb.errAmount = 0
					cb.state = Open
					cb.mu.Unlock()
					go func() {
						time.Sleep(5 * time.Second)
						cb.mu.Lock()
						cb.state = HalfOpen
						cb.mu.Unlock()
						fmt.Printf("slept for 5 sec, switching to half open\n")
					}()
				} else {
					cb.mu.Unlock()
				}
			}
		}
	}()
	return cb
}

func (cb *CircuitBreaker) Close() {
	cb.closeChan <- struct{}{}
}

func (cb *CircuitBreaker) Launch(f WebFunc) (t any, e error) {
	cb.mu.RLock()
	if cb.state == Open {
		fmt.Printf("CB is open, return :( \n")
		cb.mu.RUnlock()
		return nil, ErrOpen
	}
	if cb.state == HalfOpen {
		cb.mu.RUnlock()
		fmt.Printf("Launch half-open\n")
		if cb.mu.TryLock() {
			// allow one attempt
			ret, e := f()
			if e != nil {
				fmt.Printf("Error on half-open\n")
				cb.errPropagation <- struct{}{}
				cb.mu.Unlock()
				return nil, e
			}
			fmt.Printf("Success on half-open\n")
			cb.state = Closed
			cb.mu.Unlock()
			return ret, nil
		}

		fmt.Printf("CB is closed, probing in another thread\n")
		return nil, ErrOpen
	}

	cb.mu.RUnlock()
	ret, e := f()
	if e != nil {
		fmt.Printf("Error on calling func\n")
		cb.errPropagation <- struct{}{}
		return nil, e
	}
	fmt.Printf("No error\n")
	return ret, nil
}

func main() {
	cb := NewCircuitBreaker()
	stop := make(chan struct{})

	for i := 0; i < 10; i++ {
		go func() {
			for {
				select {
				case <-stop:
					return
				default:
					cb.Launch(Test)
					time.Sleep(200 * time.Millisecond)
				}
			}
		}()
	}

	time.Sleep(time.Second * 60)
	close(stop)
}

func Test() (any, error) {
	s := rand.Int31n(100)
	time.Sleep(time.Duration(s) * time.Millisecond * 100)
	if s < 70 {
		return s, nil
	}
	fmt.Printf("generated error\n")
	return 0, errors.New("random number overflow")
}
