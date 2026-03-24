package main

import (
	"context"
	"fmt"
	"time"
)

func main() {

	ch := make(chan int)
	ctx, cancel := context.WithCancel(context.Background())
	go ping(ch, ctx)
	go pong(ch, ctx)
	ch <- 0
	time.Sleep(1 * time.Second)
	cancel()
}

func ping(ch chan int, ctx context.Context) {
	for {
		select {
		case v := <-ch:
			if v > 10 {
				fmt.Println("exit")
				return
			}
			fmt.Println("ping", v)
			ch <- v + 1
		case <-ctx.Done():
			return
		}
	}
}

func pong(ch chan int, ctx context.Context) {
	for {
		select {
		case v := <-ch:
			if v > 10 {
				fmt.Println("exit")
				return
			}
			fmt.Println("pong", v)
			ch <- v + 1
		case <-ctx.Done():
			return
		}
	}
}
