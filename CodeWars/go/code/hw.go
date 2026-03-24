package main

import (
	"context"
	"errors"
	"time"
)

func main() {

}

func doWork(ch <-chan string) (string, error) {
	select {
	case result := <-ch:
		return result, nil
	case <-time.After(2 * time.Second):
		return "", errors.New("timeout")
	}
}

func doWork2(ctx context.Context, ch <-chan string) (string, error) {
	ctx, cancel := context.WithTimeout(ctx, 2*time.Second)
	defer cancel() // always call cancel to free resources

	select {
	case result := <-ch:
		return result, nil
	case <-ctx.Done():
		return "", ctx.Err() // context.DeadlineExceeded
	}
}
