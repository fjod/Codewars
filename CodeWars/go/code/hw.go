package main

import (
	"fmt"
)

func kItemsWithMaximumSum(numOnes int, numZeros int, numNegOnes int, k int) int {

	if k <= numOnes {
		return k
	}
	if k <= numOnes+numZeros {
		return numOnes
	}
	left := k - (numZeros + numOnes)
	return numOnes - left
}

func main() {
	t := kItemsWithMaximumSum(6, 6, 6, 13)
	fmt.Println(t)
}
