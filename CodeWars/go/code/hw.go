package main

import (
	"context"
	"time"
)

// mock func to get response time
func textSearcher(ctx context.Context, name string) (time.Duration, error) {
	return 10 * time.Second, nil
}

func getFastestTextSearcher(ctx context.Context, searchers []string) (name string, respTime time.Duration, err error) {
	c, cancel := context.WithCancel(ctx)
	defer cancel()
	type searchResult struct {
		name     string
		respTime time.Duration
		err      error
	}
	var retE error
	ch := make(chan searchResult, len(searchers)) // buffered channel
	for _, n := range searchers {
		go func(n string) {
			dur, e := textSearcher(c, n)
			ch <- searchResult{name, dur, e}
		}(n)
	}

	for range searchers {
		r := <-ch
		if r.err != nil {
			cancel()
			return r.name, r.respTime, nil
		}
	}
	return "", 0, retE
}

func main() {

}
