package main

import (
	"fmt"
	"strings"
),
	"strings"
)

func isAlienSorted(words []string, order string) bool {

	for i := 1; i < len(words); i++ {
		prev := words[i-1]
		curr := words[i]
		for j := 0; j < len(prev); j++ {
			prevChar := prev[j]
			if j >= len(curr) {
				return false
			}
			currChar := curr[j]
			if prevChar != currChar {
				if strings.Index(order, string(prevChar)) > strings.Index(order, string(currChar)){
					return false
				}
				break
			}
		}
	}
	return true
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
