package main

import (
	"fmt"
	"strings"
),
	"strings"
)

func findLHS(nums []int) int {

	var max int
	dict := make(map[int]int)
	for _, v := range nums {
		dict[v]++
	}

	for k, v := range dict {
		next, ok := dict[k + 1]
		if ok {
			if v+next > max {
				max = v + next
			}
		}
	}
	return max
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
