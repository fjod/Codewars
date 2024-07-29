package main

import (
	"fmt"
)

func resultArray(nums []int) []int {
	arr1 := make([]int, len(nums))
	arr1Counter := 0
	arr2 := make([]int, len(nums))
	arr2Counter := 0
	arr1[arr1Counter] = nums[0]
	arr1Counter++
	arr2[arr2Counter] = nums[1]
	arr2Counter++
	for i := 2; i < len(nums); i++ {
		if arr1[arr1Counter-1] > arr2[arr2Counter-1] {
			arr1[arr1Counter] = nums[i]
			arr1Counter++
		} else {
			arr2[arr2Counter] = nums[i]
			arr2Counter++
		}
	}

	ret := make([]int, len(nums))
	for i := 0; i < arr1Counter; i++ {
		ret[i] = arr1[i]
	}
	for i := 0; i < arr2Counter; i++ {
		ret[i+arr1Counter] = arr2[i]
	}
	return ret
}

func bubbleSort(nums []int) {
	l := len(nums)
	inner := l - 1
	for i := 0; i < l; i++ {
		for j := 0; j < inner; j++ {
			if nums[j] > nums[i] {
				temp := nums[j]
				nums[j] = nums[i]
				nums[i] = temp
			}
		}
	}
}

func main() {
	slice := []int{1, 2, 5, 15, 20}

	fmt.Println(slice)
	fmt.Println(resultArray(slice))
}
