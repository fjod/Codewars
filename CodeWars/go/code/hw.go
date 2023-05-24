package main

import (
	"fmt"
)
import "strings"

func defangIPaddr(address string) string {
	arr := strings.Split(address, ".")
	return strings.Join(arr, "[.]")
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
