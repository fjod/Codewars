package main

func addDigits(num int) int {
	var ret = 0
	if num < 10 {
		return num
	}
	for num > 0 {
		ret += num % 10
		num /= 10
	}
	return addDigits(ret)
}

func main() {

}
