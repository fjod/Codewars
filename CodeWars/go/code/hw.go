package main

import (
	"fmt"
	"strconv"
	"time"
)

type minHourTime struct {
	value  time.Duration
	isHour bool
}

func readBinaryWatch(turnedOn int) []string {
	var ret []string
	leds := make([]minHourTime, 10)
	leds[0] = minHourTime{time.Minute * 1, false}
	leds[1] = minHourTime{time.Minute * 2, false}
	leds[2] = minHourTime{time.Minute * 4, false}
	leds[3] = minHourTime{time.Minute * 8, false}
	leds[4] = minHourTime{time.Minute * 16, false}
	leds[5] = minHourTime{time.Minute * 32, false}
	leds[6] = minHourTime{time.Hour * 1, true}
	leds[7] = minHourTime{time.Hour * 2, true}
	leds[8] = minHourTime{time.Hour * 4, true}
	leds[9] = minHourTime{time.Hour * 8, true}
	current := make([]minHourTime, 0)
	helper(turnedOn, 0, &ret, &leds, &current)
	return ret
}

func remove(arr []minHourTime, index int) []minHourTime {
	return append(arr[:index], arr[index+1:]...)
}

func arrayContains(arr []string, item string) bool {
	for _, i := range arr {
		if i == item {
			return true
		}
	}
	return false
}

func helper(turnedOn int, shift int, output *[]string, leds *[]minHourTime, current *[]minHourTime) {
	if turnedOn == shift {
		totalMinutes := 0.0
		totalHours := 0.0
		for i := 0; i < len(*current); i++ {
			currentTime := (*current)[i]
			if currentTime.isHour == false {
				totalMinutes += currentTime.value.Minutes()
			}
			if currentTime.isHour {
				totalHours += currentTime.value.Hours()
			}
		}
		if totalHours < 12 && totalMinutes < 60 {
			minutesAdder := ""
			if totalMinutes < 10 {
				minutesAdder = "0"
			}
			str := fmt.Sprintf("%s:%s", strconv.Itoa(int(totalHours)), minutesAdder+strconv.Itoa(int(totalMinutes)))
			if arrayContains(*output, str) == false {
				*output = append(*output, str)
			}

		}
	}
	if turnedOn != shift {
		for i := 0; i < len(*leds); i++ {
			*current = append(*current, (*leds)[i])
			local := make([]minHourTime, len(*leds)-1)
			copy(local, append((*leds)[:i], (*leds)[i+1:]...))
			helper(turnedOn, shift+1, output, &local, current)
			*current = remove(*current, len(*current)-1)
		}
	}
}

func main() {
	t := readBinaryWatch(2)
	fmt.Println(t)
}
