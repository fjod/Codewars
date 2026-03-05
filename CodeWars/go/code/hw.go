package main

import (
	"context"
	"fmt"
	"io"
	"net/http"
	"time"
)

type HttpRequester struct {
	timeout time.Duration
}

type HttpResponse struct {
	Body string
	Err  error
}

func (r HttpRequester) Fetch(addr string) {
	ctx, cancel := context.WithTimeout(context.Background(), r.timeout)
	defer cancel()
	respChan := make(chan HttpResponse, 1)

	go func() {
		req, err := http.NewRequestWithContext(ctx, http.MethodGet, addr, nil)

		if err != nil {
			fmt.Println("Error:", err)
			respChan <- HttpResponse{Err: err}
			return
		}

		body, err := io.ReadAll(req.Body)
		if err != nil {
			fmt.Println("Error reading response:", err)
			respChan <- HttpResponse{Err: err}
			return
		}
		defer req.Body.Close()

		respChan <- HttpResponse{Body: string(body)}
	}()

	select {
	case resp := <-respChan:
		{
			fmt.Println("Response:", resp.Body)
			return
		}
	case <-ctx.Done():
		{
			fmt.Println("Timeout")
			return
		}
	}
}

func main() {
	r := HttpRequester{timeout: 400 * time.Millisecond}
	r.Fetch("http://www.google.com")
}
