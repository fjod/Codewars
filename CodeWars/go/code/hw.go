package main

import (
	"fmt"
	"strings"
),
	"strings"
)

func distanceBetweenBusStops(distance []int, start int, destination int) int {

	forward := 0
	backward := 0
	if start < destination{
		for i:=start;i<destination;i++{
			forward += distance[i]
		}
		for i:=destination;i<len(distance);i++{
			backward += distance[i]
		}
		for i:=0;i<start;i++{
			backward += distance[i]
		}
	} else {
		for i:=destination;i<start;i++{
			backward += distance[i]
		}
		for i:=start;i<len(distance);i++{
			forward += distance[i]
		}
		for i:=0;i<destination;i++{
			forward += distance[i]
		}
	}
	if forward < backward{
		return forward
	}
	return backward
}

func main() {
	t := detectCapitalUse("USA")
	fmt.Println(t)
}
