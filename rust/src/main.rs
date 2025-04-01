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
    let v2 = Rc::new(RefCell::new(TreeNode::new(2)));
    let v3 = Rc::new(RefCell::new(TreeNode::new(3)));

    // Build the tree
    v3.borrow_mut().left = Some(v1);
    v3.borrow_mut().right = Some(v2);

    let v11 = Rc::new(RefCell::new(TreeNode::new(1)));
    let v21 = Rc::new(RefCell::new(TreeNode::new(2)));
    let v31 = Rc::new(RefCell::new(TreeNode::new(3)));

    // Build the tree
    v31.borrow_mut().left = Some(v11);
    v31.borrow_mut().right = Some(v21);

    // Perform inorder traversal
    let result = is_same_tree(Some(v3), Some(v31));
    println!("Inorder Traversal Result: {:?}", result);
} 

pub fn is_same_tree(p: Option<Rc<RefCell<TreeNode>>>, q: Option<Rc<RefCell<TreeNode>>>) -> bool {
        if (p.is_none() && q.is_none()) {
            return true;
        }
        if (p.is_none() && !q.is_none()) {
            return false;
        }
        if (!p.is_none() && q.is_none()) {
            return false;
        }
        let p_val = p.clone().unwrap().borrow().val;
        let q_val = q.clone().unwrap().borrow().val;
        if (p_val != q_val) {
            return false;
        }
        let p_left = p.clone().unwrap().borrow().left.clone();
        let q_left = q.clone().unwrap().borrow().left.clone();
        let left_same = is_same_tree(p_left, q_left);
        if (left_same == false) {
            return false;
        }
        let p_right = p.clone().unwrap().borrow().right.clone();
        let q_right = q.clone().unwrap().borrow().right.clone();
        let right_same = is_same_tree(p_right, q_right);
        if (right_same == false) {
            return false;
        }
        return true;
}

// cleaner code with pattern matching
pub fn is_same_tree(p: Option<Rc<RefCell<TreeNode>>>, q: Option<Rc<RefCell<TreeNode>>>) -> bool {
    match (p, q) {
        (None, None) => true,                // Both are None, trees are identical
        (Some(_), None) | (None, Some(_)) => false, // One is None, the other isn't
        (Some(p_node), Some(q_node)) => {
            // Borrow both nodes once
            let p_borrow = p_node.borrow();
            let q_borrow = q_node.borrow();

            // Compare values and recursively check left and right subtrees
            p_borrow.val == q_borrow.val &&
            is_same_tree(p_borrow.left.clone(), q_borrow.left.clone()) &&
            is_same_tree(p_borrow.right.clone(), q_borrow.right.clone())
        }
    }
}

// no cloning if passed by reference
pub fn is_same_tree(p: &Option<Rc<RefCell<TreeNode>>>, q: &Option<Rc<RefCell<TreeNode>>>) -> bool {
    match (p, q) {
        (None, None) => true,
        (Some(_), None) | (None, Some(_)) => false,
        (Some(p_node), Some(q_node)) => {
            let p_borrow = p_node.borrow();
            let q_borrow = q_node.borrow();
            p_borrow.val == q_borrow.val &&
            is_same_tree(&p_borrow.left, &q_borrow.left) &&
            is_same_tree(&p_borrow.right, &q_borrow.right)
        }
    }
}