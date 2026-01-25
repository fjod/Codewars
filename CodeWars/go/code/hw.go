package main

import (
	"context"
	"fmt"
	"math/rand"
	"time"
)

func main() {

	sendChan := make(chan int, 5) // buffered to prevent blocking
	ctx, cancel := context.WithCancel(context.Background())
	defer cancel() // cleanup

	for i := 0; i < 5; i++ {
		go getData(sendChan, ctx)
	}

	// Get first result
	result := <-sendChan
	fmt.Printf("%d\n", result)

	// Cancel all other goroutines
	cancel()

	// Give them time to clean up
	time.Sleep(100 * time.Millisecond)
}

func getData(c chan int, ctx context.Context) {

	dur := time.Duration(rand.Intn(1000)) * time.Millisecond
	ticker := time.NewTicker(dur)
	for {
		select {
		case <-ctx.Done():
			return
		case <-ticker.C:
			c <- int(dur.Milliseconds())
			return
		}
	}

}
