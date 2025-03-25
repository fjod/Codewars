mod data;

use std::{cell::RefCell, rc::Rc, result};

use data::tree::TreeNode; // Refers to ListNode in src/data/data.rs

/*
Summary
Rc: Enables shared ownership of data.
RefCell: Enables interior mutability by enforcing borrowing rules at runtime.
Together: They allow shared, mutable data structures like trees or graphs.
*/
fn main() {
  
    let v1 = Rc::new(RefCell::new(TreeNode::new(1)));
    let v2 = Rc::new(RefCell::new(TreeNode::new(5)));
    let v3 = Rc::new(RefCell::new(TreeNode::new(3)));

    // Build the tree
    v3.borrow_mut().left = Some(v1);
    v3.borrow_mut().right = Some(v2);

    // Perform inorder traversal
    let result = inorder_traversal(Some(v3));
    println!("Inorder Traversal Result: {:?}", result);
} 

pub fn inorder_traversal(root: Option<Rc<RefCell<TreeNode>>>) -> Vec<i32> {
    let mut result = Vec::new();
    helper(root, &mut result);
    result
}

fn helper(node: Option<Rc<RefCell<TreeNode>>>, result: &mut Vec<i32>) {
    if let Some(node) = node {
        helper(node.borrow().left.clone(), result);
        result.push(node.borrow().val);
        helper(node.borrow().right.clone(), result);
    }
}