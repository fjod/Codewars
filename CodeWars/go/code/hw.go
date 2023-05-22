package main

import (
	"fmt"
)

func sumPrev(start int) int64 {
	var sum int64 = 0
	for i := 0; i < start; i++ {
		sum += int64(i)
	}
	return sum
}
func countPairs(deliciousness []int) int {

	var count int64 = 0
	dictionary := make(map[int]int)
	for _, num := range deliciousness {
		dictionary[num]++
	}

	powersOfTwo := make(map[int]int)
	for i := 0; i <= 21; i++ {
		powersOfTwo[i] = 1 << i
	}

	for inputValue, amountOfInputValue := range dictionary {
		for _, powerOfTwo := range powersOfTwo {
			target := powerOfTwo - inputValue
			if target == inputValue {
				count += sumPrev(amountOfInputValue)
			}

			amountOfCurrent, ok := dictionary[target]
			if target > inputValue && ok {
				var temp int64 = int64(amountOfCurrent) * int64(amountOfInputValue)
				count += temp
			}
		}
	}

	return (int)(count % 1000000007)
}

func main() {
	candidates := []int{2, 3, 6, 7}
	t := combinationSum(candidates, 7)
	fmt.Println(t)
}
