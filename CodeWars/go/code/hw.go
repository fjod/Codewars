package main

import (
	"fmt"
)

func truncateSentence(s string, k int) string {
	spaces := 0
	for i := 0; i < len(s); i++ {
		if s[i] == ' ' {
			spaces++
		}
		if spaces == k {
			return s[:i]
		}
	}
	return s
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
