package main

import (
	"fmt"
)

func rowAndMaximumOnes(mat [][]int) []int {
    prevSum := 0
	biggestIndex := 0
	size := len(mat)
	for i := 0; i < size; i++ {
		current:= len(mat[i])
		sum := 0
		for j:=0; j < current; j++{
			sum += mat[i][j]
		}
		if (sum > prevSum){
			prevSum = sum
			biggestIndex = i
		}
	}

	return []int {biggestIndex, prevSum}
}

func main() {
	a := [][]int{
		{0, 0},
		{1, 1},
		{0, 0},
	}
	test := rowAndMaximumOnes(a)
	fmt.Printf("%d", test[0])
	fmt.Printf("%d", test[1])
  }