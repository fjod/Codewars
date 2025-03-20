mod data;

use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let mut head = ListNode::new(1);
    let next = ListNode::new(1);
    head.next = Some(Box::new(next));
    let next = ListNode::new(2);    
    head.next.as_mut().unwrap().next = Some(Box::new(next));

    let result = delete_duplicates(Some(Box::new(head)));  
    println!("result {:?}", result);
} 

pub fn delete_duplicates(mut head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
    let mut current = &mut head;
    while let Some(ref mut node) = current {
        while let Some(ref next) = node.next {
            if node.val == next.val {
                node.next = next.next.clone();
            } else {
                break;
            }
        }
        current = &mut node.next;
    }
    head
}

// ownership gymnastics
pub fn delete_duplicates2(mut head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
    let mut current = &mut head;
    while let Some(node) = current.take() {
        let mut node = node;
        let mut next_opt = node.next.take();
        while let Some(mut next) = next_opt {
            if node.val == next.val {
                next_opt = next.next.take();
            } else {
                node.next = Some(next);
                break;
            }
        }
        *current = Some(node);
        current = &mut current.as_mut().unwrap().next;
    }
    head
}