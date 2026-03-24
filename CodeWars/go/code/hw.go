package main

import (
	"runtime"
	"time"
)

func main() {

	ch := make(chan int)
	num := runtime.NumGoroutine()
	println(num)
	for i := 0; i < 10; i++ {
		go Test(ch)
	}
	time.Sleep(1 * time.Second)
	num = runtime.NumGoroutine()
	println(num)
	for i := 0; i < 10; i++ {
		go Test(ch)
	}
	time.Sleep(1 * time.Second)
	num = runtime.NumGoroutine()
	println(num)
	for i := 0; i < 10; i++ {
		go Test(ch)
	}
	time.Sleep(2 * time.Second)
}

func Test(ch chan int) {
	<-ch
}

/*
  Expose the metric:
  // in your /metrics handler (prometheus)
  prometheus.NewGaugeFunc(prometheus.GaugeOpts{
      Name: "go_goroutines",
      Help: "Number of goroutines",
  }, func() float64 {
      return float64(runtime.NumGoroutine())
  })

  Note: if you use the default prometheus.DefaultRegisterer, go_goroutines is already collected automatically by promhttp.

  What "healthy" looks like in Grafana:
  - Stable plateau after startup warmup
  - Slight bumps under load, then return to baseline
  - Proportional to active connections/requests (not monotonically growing)

  Red flags:
  - Monotonically increasing count (like your test) → leak
  - Count never dropping after traffic subsides → goroutines stuck on blocking ops (channels, locks, I/O)*/
