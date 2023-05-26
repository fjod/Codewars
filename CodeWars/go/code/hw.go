package main

import (
	"fmt"
	"unicode"
)

func detectCapitalUse(word string) bool {

	if len(word) == 1 {
		return true
	}
	if unicode.IsUpper(rune(word[0])) {
		if unicode.IsUpper(rune(word[1])) {
			for i := 2; i < len(word); i++ {
				if unicode.IsLower(rune(word[i])) {
					return false
				}
			}

			return true
		}
	}

	for i := 1; i < len(word); i++ {
		if unicode.IsUpper(rune(word[i])) {
			return false
		}
	}

	return true
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
