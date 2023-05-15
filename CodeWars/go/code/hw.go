package main

import (
	"fmt"
)

func getMaximumGenerated(n int) int {

	if n < 2 {
		return n
	}

	maxRet := 1
	nums := make([]int, n+1)
	nums[0] = 0
	nums[1] = 1
	for i := 2; i < n+1; i++ {
		if i%2 == 0 {
			nums[i] = nums[i/2]
		}
		if i%2 != 0 {
			nums[i] = nums[i/2] + nums[i/2+1]
		}
		maxRet = max(maxRet, nums[i])
	}

	return maxRet
}

func main() {
	t := getMaximumGenerated(7)
	fmt.Println(t)
}
