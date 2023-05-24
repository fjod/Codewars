package main

import (
	"fmt"
	"strings"
)

func numJewelsInStones(jewels string, stones string) int {

	var count int
	for i := 0; i < len(stones); i++ {
		if contains(jewels, stones[i]) {
			count++
		}
	}

	return count
}

func contains(jewels string, u uint8) bool {
	return strings.Contains(jewels, string(u))
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
