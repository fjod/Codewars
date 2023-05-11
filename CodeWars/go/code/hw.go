package main

import (
	"fmt"
	"strings"
)

func numTilePossibilities(tiles string) int {
	m := make(map[string]bool)
	helper(tiles, &m, "")
	return len(m)
}

func addToMap(hasSet *map[string]bool, current string) {
	if current == "" {
		return
	}
	_, ok := (*hasSet)[current]
	if ok {
		return
	} else {
		(*hasSet)[current] = true
	}
}

func helper(tiles string, hasSet *map[string]bool, current string) {

	addToMap(hasSet, current)

	for i := 0; i < len(tiles); i++ {
		letter := string(tiles[i])
		addToMap(hasSet, letter)
		var sb strings.Builder
		sb.WriteString(tiles[:i])   // write part before index
		sb.WriteString(tiles[i+1:]) // write part after index
		leftTiles := sb.String()
		addToMap(hasSet, leftTiles)
		helper(leftTiles, hasSet, current+letter)
	}
}

func main() {
	t := numTilePossibilities("AAB")
	fmt.Println(t)
}
