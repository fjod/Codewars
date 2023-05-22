package main

import (
	"fmt"
)

func checkIfAllZeroes(nums []int) bool {
	for _, num := range nums {
		if num != 0 {
			return false
		}
	}
	return true
}

func findLowestNonZero(nums []int) int {
	lowest := 1000
	for _, num := range nums {
		if num != 0 && num < lowest {
			lowest = num
		}
	}
	return lowest
}

func minimumOperations(nums []int) int {

	if len(nums) == 0 {
		return 0
	}
	count := 0
	for true {
		zeroes := checkIfAllZeroes(nums)
		if zeroes {
			return count
		}

		min := findLowestNonZero(nums)

		if min == -1 {
			return count
		}

		for i := 0; i < len(nums); i++ {
			nums[i] = nums[i] - min
			if nums[i] < 0 {
				nums[i] = 0
			}
		}

		count++
	}

	return count
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
