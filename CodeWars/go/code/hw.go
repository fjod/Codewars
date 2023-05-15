package main

import (
	"fmt"
)

func allPossibleFBT(n int) []*TreeNode {
	var myMap map[int][]*TreeNode     // declares an uninitialized map
	myMap = make(map[int][]*TreeNode) // initializes an empty map with the make() function
	n0 := make([]*TreeNode, 0, 0)
	myMap[0] = n0

	n1 := make([]*TreeNode, 0, 0)
	newNode := TreeNode{
		Val:   0,
		Left:  nil,
		Right: nil,
	}
	n1 = append(n1, &newNode)
	myMap[1] = n1

	for i := 2; i <= n; i++ {
		var current = CreateNewNode()
		myMap[i] = current

		for left := 1; left < i; left++ {
			right := i - left - 1
			forwardTree := myMap[left]
			backwardTree := myMap[right]
			if len(forwardTree) > 0 && len(backwardTree) > 0 {
				for _, leftNode := range forwardTree {
					for _, rightNode := range backwardTree {
						newNode := TreeNode{
							Val:   0,
							Left:  leftNode,
							Right: rightNode,
						}
						current = append(current, &newNode)
						myMap[i] = current
					}
				}
			}
		}
	}

	return myMap[n]
}

func CreateNewNode() []*TreeNode {
	n1 := make([]*TreeNode, 0, 0)
	return n1
}

func main() {
	t := allPossibleFBT(7)
	fmt.Println(t)
}
