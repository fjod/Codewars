package main

import (
	"fmt"
)

func maxCount(m int, n int, ops [][]int) int {

	if len(ops) == 0 {
		return m * n
	}
	
	m = ops[0][0]
	n = ops[0][1]
	for _, op := range ops {
		m = min(m, op[0])
		n = min(n, op[1])
	}
	return m * n
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
