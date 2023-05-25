package main

import (
	"fmt"
	"math"
)

func titleToNumber(columnTitle string) int {

	ret := 0
	current := len(columnTitle) - 1
	for _, char := range columnTitle {
		var weight = int(char) - 'A' + 1
		pow := math.Pow(26, float64(current))
		ret += weight * int(pow)
		current--
	}
	return ret
}

func main() {
	w1 := []string{"leetcode", "is", "amazing", "as", "is"}
	w2 := []string{"amazing", "leetcode", "is"}
	t := countWords(w1, w2)
	fmt.Println(t)
}
