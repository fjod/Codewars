package main

func max(x, y int) int {
	if x > y {
		return x
	}
	return y
}

func sumArray(arr *[]int) int {
	sum := 0
	for _, num := range *arr {
		sum += num
	}
	return sum
}

func reverseString(s string) string {
	runes := []rune(s)
	for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
		runes[i], runes[j] = runes[j], runes[i]
	}
	return string(runes)
}
