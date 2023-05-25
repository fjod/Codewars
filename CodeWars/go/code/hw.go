package main

import (
	"fmt"
)

func maxScore(s string) int {

	ones := 0
	for _, v := range s {
		if v == '1' {
			ones++
		}
	}
	if ones == len(s) {
		return ones - 1
	}
	if ones == 0 {
		return len(s) - 1
	}
	max := 0
	zeroes := 0

	for i := 0; i < len(s)-1; i++ {
		c := s[i]
		if c == '0' {
			zeroes++
		} else {
			ones--
		}
		if zeroes+ones > max {
			max = zeroes + ones
		}
	}

	return max
}

func main() {
	w1 := []string{"leetcode", "is", "amazing", "as", "is"}
	w2 := []string{"amazing", "leetcode", "is"}
	t := countWords(w1, w2)
	fmt.Println(t)
}
