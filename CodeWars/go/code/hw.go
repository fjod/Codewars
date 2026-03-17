package main

import (
	"context"
	"errors"
	"sync"
	"time"
)

type Job struct {
	fn     Handler
	result chan Result
}

type Result struct {
	Value any
	Err   error
}

type Handler func(ctx context.Context) (any, error)

type ClassicPool struct {
	main   chan Job
	ctx    context.Context
	cancel context.CancelFunc
	wg     sync.WaitGroup
}

func NewClassicPool(workersNum int) *ClassicPool {
	ctx, cancel := context.WithCancel(context.Background())

	pool := &ClassicPool{
		main:   make(chan Job, workersNum),
		ctx:    ctx,
		cancel: cancel,
		wg:     sync.WaitGroup{},
	}

	for i := 0; i < workersNum; i++ {
		pool.wg.Add(1)
		go pool.worker()
	}

	return pool
}

func (c *ClassicPool) Cancel() {
	c.cancel() // cancel context which goes inside workers
	defer c.drainLeftOvers()
	timeout, cancel := context.WithTimeout(context.Background(), time.Second)
	defer cancel()
	wgReadyChan := make(chan struct{})
	go func() {
		c.wg.Wait()
		close(wgReadyChan)
	}()
	select {
	case <-timeout.Done():
		println("timeout")
		return
	case <-wgReadyChan:
		println("done")
		return
	}
}

func (c *ClassicPool) drainLeftOvers() {
	for {
		select {
		case job := <-c.main:
			job.result <- Result{Err: context.Canceled}
		default:
			return // channel empty, stop draining
		}
	}
}

func (c *ClassicPool) worker() {
	defer c.wg.Done()
	for {
		select {
		case job := <-c.main:
			val, err := job.fn(c.ctx)
			job.result <- Result{val, err}

		case <-c.ctx.Done():
			return
		}
	}
}

func (c *ClassicPool) Do(fn Handler) (<-chan Result, error) {
	job := Job{fn: fn, result: make(chan Result, 1)}
	select {
	case c.main <- job: // pool is alive, job accepted
		return job.result, nil
	case <-c.ctx.Done():
		return nil, c.ctx.Err()
	default:
		return nil, errors.New("pool is full") // caller decides: retry, drop, wait
	}
}

func main() {

}
