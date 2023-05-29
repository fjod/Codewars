package main

import (
	"fmt"
)

func smallestEqual(nums []int) int {

	for i := 0; i < len(nums); i++ {
		if i%10 == nums[i] {
			return i
		}
	}
	return -1
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
