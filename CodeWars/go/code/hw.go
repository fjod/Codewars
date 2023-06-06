package main

import (
	"fmt"
)

func numUniqueEmails(emails []string) int {

	emailDict := make(map[string]int)
	for _, email := range emails {
		converted := conv(email)
		emailDict[converted]++
	}
	return len(emailDict)
}

func conv(email string) string {
	ignoreCurrent := false
	conv := make([]rune, 0, len(email))
	for i := 0; i < len(email); i++ {
		current := email[i]
		if current == '.' {
			continue
		}
		if current == '+' {
			ignoreCurrent = true
		}
		if current == '@' {
			for j := i; j < len(email); j++ {
				conv = append(conv, rune(email[j]))
			}
			return string(conv)
		}
		if ignoreCurrent == false {
			conv = append(conv, rune(current))
		}
	}
	return string(conv)
}

func main() {
	n2 := []int{3, 5, 2, 6}
	n1 := []int{3, 1, 7}
	t := minNumber(n1, n2)
	fmt.Println(t)
}
