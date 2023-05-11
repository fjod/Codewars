package main

import (
	"fmt"
)

func generate(numRows int) [][]int {
	matrix := make([][]int, numRows)
	for i := range matrix {
		var slice []int
		matrix[i] = slice
	}
	gen(numRows, 0, &matrix)
	return matrix
}

func gen(numRows int, current int, ret *[][]int) {
	if current == numRows {
		return
	}

	if current == 0 {
		var slice = (*ret)[current]
		slice = append(slice, 1)
		(*ret)[current] = slice
		gen(numRows, current+1, ret)
		return
	}

	if current == 1 {
		var slice = (*ret)[current]
		slice = append(slice, 1)
		slice = append(slice, 1)
		(*ret)[current] = slice
		gen(numRows, current+1, ret)
		return
	}

	var slice = (*ret)[current]
	slice = append(slice, 1)
	for i := 1; i < current; i++ {
		var prevSlice = (*ret)[current-1]
		slice = append(slice, prevSlice[i-1]+prevSlice[i])
	}
	slice = append(slice, 1)
	(*ret)[current] = slice
	gen(numRows, current+1, ret)
}

func main() {
	t := generate(5)
	fmt.Println(t)
}
