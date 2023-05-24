package main

import (
	"fmt"
	"strings"
)

func findWords(words []string) []string {
	var res []string
	checkString(words, &res, "qwertyuiop")
	checkString(words, &res, "asdfghjkl")
	checkString(words, &res, "zxcvbnm")
	return res
}

func checkString(words []string, i *[]string, keys string) {
	for _, word := range words {
		var flag = true
		for _, letter := range word {
			if !strings.Contains(keys, strings.ToLower(string(letter))) {
				flag = false
			}
		}
		if flag {
			*i = append(*i, word)
		}
	}
}

func main() {
	w1 := []string{"leetcode", "is", "amazing", "as", "is"}
	w2 := []string{"amazing", "leetcode", "is"}
	t := countWords(w1, w2)
	fmt.Println(t)
}
