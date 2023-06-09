package main

import (
	"fmt"
)

func shuffle(nums []int, n int) []int {
	ret := make([]int, n*2)
	for i := 0; i < n; i++ {
		ret[i*2] = nums[i]
	}
	index := 1
	for i := n; i < len(nums); i++ {
		ret[index] = nums[i]
		index += 2
	}
	return ret
}

func main() {

	test := []int{2, 5, 1, 3, 4, 7}
	t := shuffle(test, 3)
	fmt.Println(t)
}
