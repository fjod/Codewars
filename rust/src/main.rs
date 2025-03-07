mod data;
use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let v = vec![1,3,5,6];
    let result = search_insert(v, 2);
    println!("result {:?}", result);
}

pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        let mut left = 0;
        let mut right =  nums.len();      
        while left < right {
            let mut mid  = left + (right - left) / 2;
            let curr = nums[mid];          
            if curr < target {
                left = mid + 1;                
            } else {
                right = mid;                
            }
        }
        return left as i32
}