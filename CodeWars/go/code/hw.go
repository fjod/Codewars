package main

import (
	"fmt"
)

func minimumTotal(triangle [][]int) int {
	for i := len(triangle) - 2; i >= 0; i-- {
		for j := 0; j < len(triangle[i]); j++ {
			triangle[i][j] += min(triangle[i+1][j], triangle[i+1][j+1])
		}
	}
	return triangle[0][0]
}

func main() {
	test := [][]int{{1, 2, 3}, {1, 2, 3}}
	fmt.Println("test")
	minimumTotal(test)
}
