package main

import (
	"fmt"
)

func rotateGrid(grid [][]int, k int) [][]int {
	bottom := len(grid) - 1
	right := len(grid[0]) - 1
	top := 0
	left := 0

	for true {

		totalLayerElements := 2*(bottom-top) + 2*(right-left)
		numOfRotations := k % totalLayerElements

		for i := 0; i < numOfRotations; i++ {
			temp := grid[top][left]
			for j := left; j < right; j++ {
				grid[top][j] = grid[top][j+1]
			}

			for j := top; j < bottom; j++ {
				grid[j][right] = grid[j+1][right]
			}

			for j := right; j > left; j-- {
				grid[bottom][j] = grid[bottom][j-1]
			}

			for j := bottom; j > top; j-- {
				grid[j][left] = grid[j-1][left]
			}

			grid[top+1][left] = temp

		}

		top++
		left++
		bottom--
		right--
		if bottom <= top || right <= left {
			break
		}
	}
	return grid
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
