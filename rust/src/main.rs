mod data;

use std::result;

use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let mut v1 = vec![4,0,0,0,0,0];
    let mut v2 = vec![1,2,3,5,6];
    merge(&mut v1, 1, &mut v2, 5);
    println!("result {:?}", v1);
} 
// failed to solve it myself, tried to go forwad from the start of the array, but it was too complicated
pub fn merge(nums1: &mut Vec<i32>, m: i32, nums2: &Vec<i32>, n: i32) {
    let mut k = (m + n - 1) as usize;  // Points to the last position in nums1 (where to place element)
    let mut i = (m - 1) as i32;        // Points to the last element in nums1's original data
    let mut j = (n - 1) as i32;        // Points to the last element in nums2
    
    while j >= 0 {// Works backwards from the end of nums1
        if i >= 0 && nums1[i as usize] > nums2[j as usize] { // If the element is greater and there are still elements in nums1
            nums1[k] = nums1[i as usize]; // Place larger nums1 element from original data
            i -= 1; // shift original data pointer
        } else {
            nums1[k] = nums2[j as usize]; // Place nums2 element
            j -= 1; // shift new data
        }
        k = k.wrapping_sub(1); // move new element pointer to the left either way
    }
}