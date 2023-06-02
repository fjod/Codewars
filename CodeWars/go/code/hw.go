package main

import (
	"fmt"
)

func findMin(nums []int) int {
	ret := 10
	for _, num := range nums {
		if num < ret {
			ret = num
		}
	}
	return ret
}

func ifContains(m map[int]bool, nums1 []int) int {
	dup := 10
	for i := 0; i < len(nums1); i++ {
		_, ok := m[nums1[i]]
		if ok {
			if nums1[i] < dup {
				dup = nums1[i]
			}
		}
	}
	if dup != 10 {
		return -1
	}
	return dup
}

func minNumber(nums1 []int, nums2 []int) int {
	m := make(map[int]bool)
	if len(nums1) > len(nums2) {
		for i := 0; i < len(nums2); i++ {
			m[nums2[i]] = true
		}
		ret := ifContains(m, nums1)
		if ret != -1 {
			return ret
		}
	} else {
		for i := 0; i < len(nums1); i++ {
			m[nums1[i]] = true
		}
		ret := ifContains(m, nums2)
		if ret != -1 {
			return ret
		}
	}
	fst := findMin(nums1)
	snd := findMin(nums2)
	v1 := fst*10 + snd
	v2 := fst + snd*10
	if v1 > v2 {
		return v2
	}
	return v1
}

func main() {
	n2 := []int{3, 5, 2, 6}
	n1 := []int{3, 1, 7}
	t := minNumber(n1, n2)
	fmt.Println(t)
}
