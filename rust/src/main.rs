mod data;

use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let result = climb_stairs(5);  
    println!("result {:?}", result);
} 

pub fn climb_stairs(n: i32) -> i32 {
        if n == 1 {
            return 1;
        }
        if n == 2 {
            return 2;
        }
        if n == 3 {
            return 3;
        }
        let mut dp = vec![0; n as usize];
        dp[0] = 1;
        dp[1] = 2;
        dp[2] = 3;
        for i in 3..n as usize {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        dp[n as usize - 1]
}