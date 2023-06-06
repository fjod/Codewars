package main

import (
	"fmt"
)

func diagonalSum(mat [][]int) int {

	if len(mat) == 1 {
		return mat[0][0]
	}
	sum := 0
	for i := 0; i < len(mat); i++ {
		sum += mat[i][i]
	}

	for i := len(mat) - 1; i >= 0; i-- {
		sum += mat[i][len(mat)-i-1]
	}

	if len(mat)%2 == 0 {
		return sum
	}

	mid := len(mat) / 2
	return sum - mat[mid][mid]
}

func main() {

	n1 := []int{7, 3, 1, 9}
	n2 := []int{3, 4, 6, 9}
	n3 := []int{6, 9, 6, 6}
	n4 := []int{9, 5, 8, 5}
	n5 := [][]int{n1, n2, n3, n4}
	t := diagonalSum(n5)
	fmt.Println(t)
}
