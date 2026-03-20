package main

import "fmt"

type MyError struct {
	msg string
}

func (m MyError) Error() string {
	return m.msg
}

func ReturnNotNil() error {
	var p *MyError = nil
	return p
}

func ReturnNotNilCorrect() error {
	var p *MyError = nil
	if p == nil {
		return nil // return untyped nil, not the typed pointer
	}
	return p
}

func ReturnNil() *MyError {
	var p *MyError = nil
	return p
}

type CustomString struct {
	str string
}

func (c CustomString) String() string {
	return c.str
}

func main() {
	var isNil = ReturnNotNil() == nil
	fmt.Printf("The code is %v\n", isNil)

	isNil = ReturnNotNilCorrect() == nil
	fmt.Printf("The code is %v\n", isNil)

	isNil = ReturnNil() == nil
	fmt.Printf("The code is %v\n", isNil)

	var customString = CustomString{"hello"}
	fmt.Println(customString)
	/*
	 // Simplified version of what fmt does internally
	  if s, ok := v.(fmt.Stringer); ok {
	      output = s.String()  // uses YOUR method
	  } else {
	      output = reflect.TypeOf(v)...  // ugly default
	  }
	*/

}
