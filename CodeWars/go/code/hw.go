package main

func canWinNim(n int) bool {
	if n == 4 {
		return false
	}
	if n == 1 || n == 2 || n == 3 {
		return true
	}
	if n > 4 {
		if n%4 == 0 {
			return false
		}
	}
	return true
}

func main() {

}
