package main

import (
	"fmt"
)

func finalValueAfterOperations(operations []string) int {

	i := 0
	for _, operation := range operations {
		switch operation {
		case "--X":
			i = i - 1
		case "++X":
			i = i + 1
		case "X--":
			i = i - 1
		case "X++":
			i = i + 1
		}
	}
	return i
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
