package main

import (
	"fmt"
)

func mergeTrees(root1 *TreeNode, root2 *TreeNode) *TreeNode {

	if root1 == nil {
		return root2
	}

	if root2 == nil {
		return root1
	}

	mergeInner(root1, root2)
	return root1
}

func mergeInner(root1 *TreeNode, root2 *TreeNode) {
	if root1 == nil {
		root1 = root2
		return
	}
	if root2 != nil {
		root1.Val += root2.Val
		if root1.Left == nil {
			root1.Left = root2.Left
		} else {
			mergeInner(root1.Left, root2.Left)
		}

		if root1.Right == nil {
			root1.Right = root2.Right
		} else {
			mergeInner(root1.Right, root2.Right)
		}

	}
}

func main() {
	n2 := []int{3, 5, 2, 6}
	n1 := []int{3, 1, 7}
	t := minNumber(n1, n2)
	fmt.Println(t)
}
