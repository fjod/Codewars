package main

import (
	"errors"
	"fmt"
	"math/rand"
	"sync"
	"time"
)

type WebFunc func() (t any, e error)

var (
	ErrRejected = errors.New("rejected")
)

type TokenBucket struct {
	lastRefill  time.Time
	rate        float64
	tokenAmount float64
	tokenLimit  float64
	mutex       sync.Mutex
}

func NewTokenBucket(rate float64) *TokenBucket {
	return &TokenBucket{
		lastRefill:  time.Now(),
		rate:        rate,
		tokenAmount: 10,
		tokenLimit:  10,
		mutex:       sync.Mutex{},
	}
}

func (tb *TokenBucket) Launch(f WebFunc) (any, error) {
	tb.mutex.Lock()
	timeDif := time.Since(tb.lastRefill)
	tokenAddition := (float64(timeDif.Milliseconds()) / 1000) * tb.rate
	fmt.Println("add", tokenAddition)
	tb.lastRefill = time.Now()
	tb.tokenAmount = min(tb.tokenAmount+tokenAddition, tb.tokenLimit) // add and clamp ony any refills

	if tb.tokenAmount < 1 {
		fmt.Println("not enough tokens", tb.tokenAmount)
		tb.mutex.Unlock()
		return nil, ErrRejected
	}

	tb.lastRefill = time.Now()
	tb.tokenAmount -= 1
	fmt.Println("token amount", tb.tokenAmount)
	tb.mutex.Unlock()
	return f()
}

func main() {

	stop := make(chan struct{})
	tb := NewTokenBucket(15)
	for i := 0; i < 10; i++ {
		go func() {
			ticker := time.NewTicker(time.Second)
			for {
				select {
				case <-ticker.C:
					time.Sleep(time.Duration(i) * time.Millisecond * 100)
					go tb.Launch(Test)
				case <-stop:
					ticker.Stop()
					return
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
	return s, nil
}
