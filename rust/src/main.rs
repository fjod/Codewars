// Definition for singly-linked list.
#[derive(PartialEq, Eq, Clone, Debug)]
pub struct ListNode {
  pub val: i32,
  pub next: Option<Box<ListNode>>
}

impl ListNode {
  #[inline]
  fn new(val: i32) -> Self {
   ListNode {
     next: None,
     val
   }
  }
}

fn main() {
    // Create first list: 1 -> 3
    let node1_3 = ListNode::new(3);
    let mut node1_2 = ListNode::new(2);
    let mut node1_1 = ListNode::new(1);
    node1_2.next = Some(Box::new(node1_3));
    node1_1.next = Some(Box::new(node1_2));
    let list1 = Some(Box::new(node1_1));

    // Create second list: 2 -> 4
    let node2_3 = ListNode::new(4);
    let mut node2_2 = ListNode::new(3);
    let mut node2_1 = ListNode::new(1);
    node2_2.next = Some(Box::new(node2_3));
    node2_1.next = Some(Box::new(node2_2));
    let list2 = Some(Box::new(node2_1));

    // Call merge_two_lists with both lists
    let merged_list = merge_two_lists(list1, list2);        // Links node1 to node2

    println!("result {:?}", merged_list);
}
pub fn merge_two_lists(
    list1: Option<Box<ListNode>>,
    list2: Option<Box<ListNode>>) -> Option<Box<ListNode>>
{
    match (list1, list2) {
        (Some(mut node1), Some(node2)) if node1.val <= node2.val => {
            node1.next = merge_two_lists(node1.next, Some(node2));
            Some(node1)
        }
        (Some(node1), Some(mut node2)) => {
            node2.next = merge_two_lists(Some(node1), node2.next);
            Some(node2)
        },
        (Some(node1), None) => { Some(node1) },
        (None, Some(node2)) => { Some(node2) },
        (None, None) => { None }
    }
}
