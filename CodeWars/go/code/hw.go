package main

import (
	"fmt"
)

func vowelStrings(words []string, left int, right int) int {
	count := 0
	vowels := make(map[rune]bool)
	vowels['a'] = true
	vowels['e'] = true
	vowels['i'] = true
	vowels['o'] = true
	vowels['u'] = true
	for i := left; i < right; i++ {
		currentWord := words[i]
		_, okFirst := vowels[rune(currentWord[0])]
		_, okLast := vowels[rune(currentWord[len(currentWord)])]
		if okLast && okFirst {
			count++
		}
	}

	return count
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
