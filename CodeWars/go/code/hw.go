package main

import (
	"encoding/json"
	"fmt"
)

func main() {

	var m = make([]int, 3, 5) // slice with 3 zeroes in array of 5 elements
	jm, _ := json.Marshal(m)
	fmt.Println(string(jm)) // [0,0,0]
	m = append(m, 1)
	//printSlice(&m)

	m = []int{} // empty slice - 0 cap, 0 len
	jm, _ = json.Marshal(m)
	fmt.Println(string(jm)) // []
	m = append(m, 1)
	//printSlice(&m)

	var s []int // pointer to a nil slice of int
	js, _ := json.Marshal(s)
	fmt.Println(string(js)) // null
	s = append(s, 1)        // but append works fine because it returns new slice value (reallocate when needed)
	//printSlice(&s)

	slice := make([]int, 15)
	sub := slice[2:5]
	sub[0] = 1
	printSlice(&slice)
	printSlice(&sub)

	m = make([]int, 3, 5) // slice with 3 zeroes in array of 5 elements
	println(m)
	m = append(m, 1)
	println(m)
	m = append(m, 1)
	println(m)
	m = append(m, 1) // reallocation, cap * 2
	println(m)

	s1 := []int{0, 1, 2, 3, 4}
	sub1 := s1[1:3:3] // len=2, cap=2  (not cap=4)
	printSlice(&sub1) // 1 2
	println(sub1)

	sub1 = append(sub1, 99) // forces reallocation — won't touch s[3]  // 1 2 99 ?
	// without :3, append would write 99 into s[3]
	printSlice(&sub1)
	println(sub1)

	src := []int{1, 2, 3}
	dst := make([]int, len(src))
	copy(dst, src) //  clone a slice so mutations don't affect the original
}

func printSlice(sl *[]int) {
	for _, i := range *sl {
		print(i, " ")
	}
	println()
}
