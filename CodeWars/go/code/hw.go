package main

import "sync"

var s sync.Once

func main() {

	println(isValid("(])"))
}

func isValid(s string) bool {
	brackets := make([]byte, 0)
	if len(s) == 0 {
		return true
	}
	if len(s) == 1 {
		return false
	}

	brackets = append(brackets, s[0]) // add first
	for i := 1; i < len(s); i++ {
		cur := s[i]
		if cur == '(' || cur == '[' || cur == '{' { // add any open bracket
			brackets = append(brackets, cur)
			continue
		}
		if len(brackets) == 0 { // closing bracket on empty array
			return false
		}
		prev := brackets[len(brackets)-1]
		if (cur == ')' && prev == '(') || (cur == '}' && prev == '{') || (cur == ']' && prev == '[') {
			// remove prev bracket from slice
			brackets = brackets[:len(brackets)-1]
			continue
		}

		return false // prev bracket cant be removed, so we are stuck with wrong pair forever
	}

	return len(brackets) == 0
}
