package main

import (
	"fmt"
)

func hasPathSum(root *TreeNode, targetSum int) bool {
	if root == nil {
		return false
	}
	if root.Left == nil && root.Right == nil {
		return targetSum == root.Val
	}
	left := hasPathSum(root.Left, targetSum-root.Val)
	right := hasPathSum(root.Right, targetSum-root.Val)
	return left || right
}

func main() {
	n2 := []int{3, 5, 2, 6}
	n1 := []int{3, 1, 7}
	t := minNumber(n1, n2)
	fmt.Println(t)
}
