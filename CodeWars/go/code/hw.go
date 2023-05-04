package main

import (
	"fmt"
)

func maxProfit(prices []int) int {
	maxProfitVal := 0
	for i := 1; i < len(prices); i++ {
		maxProfitVal += max(0, prices[i]-prices[i-1])
	}

	return maxProfitVal
}

func main() {
	test := []int{7, 1, 5, 3, 6, 4}
	fmt.Println("test")
	maxProfit(test)
}
