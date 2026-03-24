package main

import (
	"fmt"
	"sync"
)

var sharedMap = make(map[string]string)
var mutex = sync.Mutex{}

func main() {
	var wg sync.WaitGroup

	for i := 0; i < 10; i++ {
		wg.Add(2)
		go func(n int) {
			defer wg.Done()
			mutex.Lock() // run with go run -race main.go  in WSL and without mutex
			sharedMap[fmt.Sprintf("key%d", n)] = "value"
			mutex.Unlock()
		}(i)
		go func(n int) {
			defer wg.Done()
			mutex.Lock()
			_ = sharedMap[fmt.Sprintf("key%d", n)]
			mutex.Unlock()
		}(i)
	}

	wg.Wait()
	fmt.Println("done, map length:", len(sharedMap))
}
