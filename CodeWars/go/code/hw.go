package main

import (
	"fmt"
	"math/rand"
	"sync"
	"time"
)

type semaphore struct {
	WaitChan chan struct{}
}

func NewSemaphore(number int) *semaphore {
	return &semaphore{make(chan struct{}, number)}
}

func (s *semaphore) acquire() {
	s.WaitChan <- struct{}{} // add one to wait queue if there is place
}
func (s *semaphore) release() {
	<-s.WaitChan
}

func main() {

	s := NewSemaphore(3)
	wg := &sync.WaitGroup{}
	for i := 0; i < 10; i++ {

		go func() {
			wg.Add(1)
			s.acquire()
			fmt.Printf("iteration %v started", i)
			fmt.Println()
			defer s.release()
			getData(wg, i)
		}()
	}
	wg.Wait()
}

func getData(wg *sync.WaitGroup, i int) {
	defer wg.Done()
	dur := time.Duration(rand.Intn(3000)) * time.Millisecond
	time.Sleep(dur)
	fmt.Printf("time is %v on %v iteration", dur, i)
	fmt.Println()
}
