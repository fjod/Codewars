package main

import (
	"fmt"
)

func checkIfExist(arr []int) bool {
	dict := make(map[float32]bool)
	for _, num := range arr {
		if dict[float32(num)/2] || dict[float32(num)*2] {
			return true
		}
		dict[float32(num)] = true
	}
	return false
}

func main() {

	n1 := []int{3, 1, 7, 11}
	t := checkIfExist(n1)
	fmt.Println(t)
}
