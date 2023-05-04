package main

func min(x, y int) int {
	if x < y {
		return x
	}
	return y
}

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
