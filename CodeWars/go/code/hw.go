package main

import (
	"context"
	"log"
	"sync"
	"time"
)

type Wrapper struct {
	timeout int
}

func (w *Wrapper) Run(fn func(ctx context.Context)) error {
	ctx, cancel := context.WithTimeout(context.Background(), time.Duration(w.timeout)*time.Second)
	defer cancel()
	wg := &sync.WaitGroup{}
	doneChan := make(chan struct{})

	wg.Add(1)
	go func() {
		defer wg.Done()
		fn(ctx)
	}()

	go func() {
		wg.Wait()
		close(doneChan)
	}()

	select {
	case <-doneChan:
		log.Println("fn completed successfully")
		return nil
	case <-ctx.Done():
		log.Println("fn timed out")
		return nil
	}
}

func main() {
	w1 := Wrapper{timeout: 3}
	go w1.Run(Wait1)

	w2 := Wrapper{timeout: 3}
	go w2.Run(Wait5)

	time.Sleep(time.Second * 4)
}

func Wait5(ctx context.Context) {
	log.Println("wait5 start")

	wg := &sync.WaitGroup{}
	doneChan := make(chan struct{})

	wg.Add(1)
	go func() {
		defer wg.Done()
		time.Sleep(5 * time.Second)
		log.Println("wait5 stop")
	}()

	go func() {
		wg.Wait()
		close(doneChan)
	}()

	select {
	case <-doneChan:
		return
	case <-ctx.Done():
		return
	}

}

func Wait1(ctx context.Context) {
	log.Println("wait1start")

	wg := &sync.WaitGroup{}
	doneChan := make(chan struct{})

	wg.Add(1)
	go func() {
		defer wg.Done()
		time.Sleep(1 * time.Second)
		log.Println("wait1 stop")
	}()

	go func() {
		wg.Wait()
		close(doneChan)
	}()

	select {
	case <-doneChan:
		return
	case <-ctx.Done():
		return
	}

}
