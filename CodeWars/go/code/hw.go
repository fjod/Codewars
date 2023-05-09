package main

import (
	"fmt"
)

func subsetXORSum(nums []int) int {
	return helper(nums, 0, 0)
}

func helper(nums []int, index int, currentXor int) int {
	if index == len(nums) {
		return currentXor
	}

	withCurrent := helper(nums, index+1, currentXor^nums[index])
	withoutCurrent := helper(nums, index+1, currentXor)
	return withoutCurrent + withCurrent
}

func main() {
	node2 := TreeNode{
		Val:   2,
		Left:  nil,
		Right: nil,
	}
	node3 := TreeNode{
		Val:   3,
		Left:  nil,
		Right: nil,
	}
	node1 := TreeNode{
		Val:   1,
		Left:  &node2,
		Right: &node3,
	}

	t := sumNumbers(&node1)
	fmt.Println(t)
}
