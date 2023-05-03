package main

import "fmt"

type TreelinkNode struct {
	Val   int
	Left  *TreelinkNode
	Right *TreelinkNode
	Next  *TreelinkNode
}

func Connect(root *TreelinkNode) *TreelinkNode {
	if root == nil || root.Left == nil {
		return root
	}
	root.Left.Next = root.Right
	if root.Next != nil {
		root.Right.Next = root.Next.Left
	}
	Connect(root.Left)
	Connect(root.Right)
	return root
}

func main() {
	fmt.Println("test")
	Connect(nil)
}
