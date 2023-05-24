package main

import (
	"fmt"
)

func countWords(words1 []string, words2 []string) int {

	dict := make(map[string]int)
	for _, word := range words1 {
		dict[word]++
	}
	for _, word := range words2 {
		v, ok := dict[word]
		if ok && v <= 1 {
			dict[word]--
		}
	}
	count := 0
	for _, v := range dict {
		if v == 0 {
			count += 1
		}
	}
	return count
}

func main() {
	w1 := []string{"leetcode", "is", "amazing", "as", "is"}
	w2 := []string{"amazing", "leetcode", "is"}
	t := countWords(w1, w2)
	fmt.Println(t)
}
