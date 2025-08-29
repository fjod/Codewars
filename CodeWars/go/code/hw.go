package main

func isPalindrome(head *ListNode) bool {
	if head == nil || head.Next == nil {
		return true // Single node or empty list is palindrome
	}

	slow, fast := head, head
	for fast != nil && fast.Next != nil {
		slow = slow.Next
		fast = fast.Next.Next
	}

	// Reverse the second half
	var prev *ListNode
	curr := slow
	for curr != nil {
		next := curr.Next // Step 1: Save Next
		curr.Next = prev  // Step 2: Reverse Connection
		prev = curr       // Step 3: Move Pointers Forward
		curr = next
	}
	// Compare first half with reversed second half
	left, right := head, prev
	for right != nil { // right will be shorter or equal length
		if left.Val != right.Val {
			return false
		}
		left = left.Next
		right = right.Next
	}

	return true
}

func main() {

}
