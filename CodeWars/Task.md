206. Reverse Linked List

Given the head of a singly linked list, reverse the list, and return the reversed list.

for iterative approach just swap arrows:
before: 1->2->3...
s1: 1<-2->3
s2 1<-2<-3
and return last object (3), so it will become 3->2->1

for recursive go back to the last item:
before: 1->2->3...
s1: return current if next = null (p = 3) for last element in list
s2: for 2 - set next.next as current(3.next = 2)
    for 2 - set next as null (2.next = null) and return p (p = 3)
s3: for 1 = set next.next as current (2.next = 1)
    for 1 - set next as null (1.next = null) and return p (p = 3)