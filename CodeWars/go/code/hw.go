package main

import (
	"fmt"
)

func countBalls(lowLimit int, highLimit int) int {
	dict := make(map[int]int)
	for i := lowLimit; i <= highLimit; i++ {
		sum := 0
		for j := i; j > 0; j /= 10 {
			sum += j % 10
		}
		dict[sum]++
	}
	max := 0
	for _, v := range dict {
		if v > max {
			max = v
		}
	}

	return max
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
