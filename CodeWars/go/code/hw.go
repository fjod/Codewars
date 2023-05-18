package main

import (
	"fmt"
)

func repeatedNTimes(nums []int) int {

	dict := make(map[int]int)
	for _, v := range nums {
		dict[v]++
	}
	n := len(nums) / 2
	for k, v := range dict {
		if v == n {
			return k
		}
	}

	return 0
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
