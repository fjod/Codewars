package main

import (
	"fmt"
	"sort"
)

type Occurence struct {
	Value int
	Amount int
}

func relativeSortArray(arr1 []int, arr2 []int) []int {
    occurences := CalcOccurencesInArr2(arr2, arr1)
	lefties := FindLeftArr1Values(arr1, occurences)
	ret := []int{}
	for i := 0; i < len(occurences); i++ {
		current := occurences[i]
		for i := 0; i < current.Amount; i++ {
			ret = append(ret, current.Value)			
		}
	}
	for i := 0; i < len(lefties); i++ {
		current := lefties[i]
		ret = append(ret, current)			
	}
	return ret
}

func CalcOccurencesInArr2(arr2 []int, arr1[]int) []Occurence {
	ret := []Occurence{}
	for i := 0; i < len(arr2); i++ {
		current := arr2[i]
		amount := 0
		for _, v := range arr1 {
			if v == current {
				amount += 1
			}
		}
		ret = append(ret, Occurence{Value: current, Amount: amount})
	}

	return ret
}

func FindLeftArr1Values(arr1 []int, occ []Occurence) []int{
	ret := []int{}
	for i := 0; i < len(arr1); i++ {
		current := arr1[i]	
		foundThisOccurence := false	
		for _, v := range occ {
			if v.Value == current {
				foundThisOccurence = true
				continue
			}
		}
		if !foundThisOccurence{
			ret = append(ret,current)
		}
		
		sort.Slice(ret, func(i, j int) bool {
			return ret[i] < ret[j]
		 })
	}

	return ret
}

func main() {
	a1 := []int{2,3,1,3,2,4,6,7,9,2,19}
	a2 := []int{2,1,4,3,9,6}
	test := relativeSortArray(a1, a2)
	fmt.Printf("%d", test)	

	a1 = []int{28,6,22,8,44,17}
	a2 = []int{22,28,8,6}
	test = relativeSortArray(a1, a2)
	fmt.Printf("%d", test)	
  }