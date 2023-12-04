package main

import (
	"fmt"
	"strconv"
)

func Reverse(s string) string {
    runes := []rune(s)
    for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
        runes[i], runes[j] = runes[j], runes[i]
    }
    return string(runes)
}

func isPalindrome(x int) bool {
    if (x < 0){return false;}
	s1 := strconv.Itoa(x)
	s2 := Reverse(s1)
	return s1 == s2
}


func isPalindrome2(x int) bool {
	if x < 0 {
		return false
	}
	r := 0
	for z := x; z > 0; z /= 10 {
		 tmp := z % 10
		 r *= 10
		 r += tmp

	}
	return r == x
}

func main() {
	test := isPalindrome2(123)
	fmt.Printf("%t", test)
  }