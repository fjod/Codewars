package main

import "fmt"

func twoSum(nums []int, target int) [2]int {
    dict := make(map[int]int)
	dict[target - nums[0]] = 0
	for i := 1; i < len(nums); i++ {
		current := nums[i] 
		index, ok := dict[current]
		if (ok){
			return [2]int{current, index}
		}
		dict[target - nums[i]] = i
	}
	panic("not found")
}

func main() {
	nums := []int{2,7,11,15}	
	ret := twoSum(nums, 9)
	fmt.Println(ret[0])
	fmt.Println(ret[1])
  }