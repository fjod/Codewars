mod data;

use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let result = my_sqrt(2147395599);
    let sqrt = (2147395599.0f32).sqrt();
    println!("result {:?} {:?}", result, sqrt);
} 

pub fn my_sqrt(x: i32) -> i32 {
        let mut left: u128 = 0;
        let mut right: u128 = x as u128;
        let mut mid: u128 = 0;
        while left <= right {
            mid = left + (right - left) / 2;

            if mid * mid == (x as u128) {                
                return mid as i32;
            }
            if mid * mid > (x as u128) {
                if (mid -1 ) * (mid -1) < (x as u128) {
                    return (mid - 1) as i32;
                }
            }

            if mid * mid < (x as u128) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        panic!("Error");
}