package main

import (
	"fmt"
)

func numWaterBottles(numBottles int, numExchange int) int {

	total := numBottles
	empties := numBottles
	for empties >= numExchange {
		exchanged := empties / numExchange
		total += exchanged
		empties = exchanged + empties%numExchange

	}

	return total
}

func main() {

	t := numWaterBottles(15, 4)
	fmt.Println(t)
}
