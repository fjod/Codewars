package main

import (
	"fmt"
)

func sumNumbers(root *TreeNode) int {
	var sums []int
	if root == nil {
		return 0
	}
	if root.Left == nil && root.Right == nil {
		return root.Val
	}

	sum(root.Val, root.Left, &sums)
	sum(root.Val, root.Right, &sums)
	return sumArray(&sums)
}

func sum(rootVal int, node *TreeNode, sums *[]int) {
	if node == nil {
		return
	}
	if node.Left == nil && node.Right == nil {
		*sums = append(*sums, rootVal*10+node.Val)
		return
	}
	sum(rootVal*10+node.Val, node.Left, sums)
	sum(rootVal*10+node.Val, node.Right, sums)
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
