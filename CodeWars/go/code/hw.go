package main

import (
	"fmt"
)

func kthDistinct(arr []string, k int) string {

	dict := make(map[string]int)
	for _, v := range arr {
		dict[v]++
	}
	for _, v := range arr {
		if dict[v] == 1 {
			k--
		}
		if k == 0 {
			return v
		}
	}

	return ""

}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
