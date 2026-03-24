package main

import (
	"context"
	"math/rand"
	"time"
)

func main() {

	ch_gen := make(chan int)
	ch_print := make(chan int)
	ctx, cancel := context.WithTimeout(context.Background(), time.Second)
	defer cancel()
	go generate(ch_gen, ctx)
	go printer(ch_print, ctx)
	go square(ch_gen, ch_print, ctx)
	time.Sleep(2 * time.Second)
}

func generate(ch chan int, ctx context.Context) {
	for {
		i := rand.Intn(590)
		select {
		case ch <- i:
			println("sent ", i)
		case <-ctx.Done():
			println("cancelled")
			return
		}
		time.Sleep(time.Duration(rand.Intn(100)) * time.Millisecond)
	}
}

func square(ch chan int, chp chan int, ctx context.Context) {
	for {
		select {
		case i := <-ch:
			chp <- i * i
			println("squared ", i*i)
		case <-ctx.Done():
			println("cancelled")
			return
		}
	}
}

func printer(chp chan int, ctx context.Context) {
	for {
		select {
		case i := <-chp:
			println("printer ", i)
		case <-ctx.Done():
			println("cancelled")
			return
		}
	}
}
