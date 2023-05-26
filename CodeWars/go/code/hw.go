package main

import (
	"fmt"
)

func largestAltitude(gain []int) int {
	current := 0
	max := -999999
	for i := 0; i < len(gain); i++ {
		current += gain[i]
		if current > max {
			max = current
		}
	}
	if max > 0 {
		return max
	}
	return 0
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
