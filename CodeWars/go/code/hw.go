package main

import (
	"fmt"
	"math/rand"
)

func sumOfMultiples(n int) int {

	sum := 0
	for i := 1; i < n; i++ {
		if i%3 == 0 {
			sum += i
			continue
		}
		if i%5 == 0 {
			sum += i
			continue
		}
		if i%7 == 0 {
			sum += i
			continue
		}
	}

	return sum
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
	test := make([]int, 30)
	for i := 0; i < len(test); i++ {
		test[i] = rand.Intn(100)
	}

	fmt.Println(test)
	bubbleSort(test)
	fmt.Println(test)
	for i := 0; i < len(test)-1; i++ {
		if test[i] > test[i+1] {
			fmt.Printf("err %d > %d\n", test[i], test[i+1])
		}
	}
}
