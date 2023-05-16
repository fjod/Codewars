package main

import (
	"fmt"
)

func countVowelStrings(n int) int {

	vowels := [5]int{1, 1, 1, 1, 1}
	if n == 0 {
		return 0
	}
	if n == 1 {
		return 1
	}
	for i := 2; i <= n; i++ {
		vowels[0] = vowels[0] + vowels[1] + vowels[2] + vowels[3] + vowels[4]
		vowels[1] = vowels[1] + vowels[2] + vowels[3] + vowels[4]
		vowels[2] = vowels[2] + vowels[3] + vowels[4]
		vowels[3] = vowels[3] + vowels[4]
	}

	return vowels[0] + vowels[1] + vowels[2] + vowels[3] + vowels[4]
}

func main() {
	t := countVowelStrings(7)
	fmt.Println(t)
}
