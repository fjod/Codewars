package main

import (
	"fmt"
)

func combinationSum(candidates []int, target int) [][]int {
	var test [][]int
	var path []int
	backTrack(0, 0, candidates, target, path, &test)
	return test
}

func backTrack(index int, total int, candidates []int, target int, path []int, result *[][]int) {
	if total == target {
		tmp := make([]int, len(path))
		copy(tmp, path)
		*result = append(*result, tmp)
		return
	}

	if total > target {
		return
	}
	if index >= len(candidates) {
		return
	}
	prevPath := path
	path = append(path, candidates[index])
	backTrack(index, total+candidates[index], candidates, target, path, result)
	path = prevPath
	backTrack(index+1, total, candidates, target, path, result)
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
