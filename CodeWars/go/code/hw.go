package main

import "fmt"

func append_to_slice(slice []int, value int, times int) []int {
	for i := 0; i < times; i++ {
		slice = append(slice, value)
	}
	return slice
}

func bad_append(slice []int, val int, times int) {
	for i := 0; i < times; i++ {
		slice = append(slice, val) // realloc happens inside for a copy, caller sees nothing
	}
}

func pointer_append(slice *[]int, val int, times int) {
	for i := 0; i < times; i++ {
		*slice = append(*slice, val) // realloc happens inside for a copy, caller sees nothing
	}
}

func main() {

	slice := make([]int, 5, 8)
	fmt.Println("before", slice)
	slice2 := append_to_slice(slice, 99, 2)
	fmt.Println("after, starting slice", slice)
	fmt.Println("after, returned slice", slice2)

	slice3 := append_to_slice(slice, 199, 5)
	fmt.Println("after2, starting slice", slice)
	fmt.Println("after2, starting slice2", slice2)
	fmt.Println("after2, returned slice3", slice3)

	slice_realloc := make([]int, 5, 6)
	fmt.Println("before", slice_realloc)
	slice_realloc_2 := append_to_slice(slice_realloc, 9, 10)
	fmt.Println("after, starting slice", slice_realloc)
	fmt.Println("after, returned slice", slice_realloc_2)

	slice_bad_realloc := make([]int, 5, 6)
	fmt.Println("before", slice_bad_realloc)
	bad_append(slice_bad_realloc, 8, 10) // struct is copied inside
	fmt.Println("after, starting slice", slice_bad_realloc)

	slice_good_realloc := make([]int, 5, 6)
	fmt.Println("before", slice_good_realloc)
	pointer_append(&slice_good_realloc, 8, 10) // using pointer, so reallocated slice is seen outside
	fmt.Println("after, starting slice", slice_good_realloc)
}
