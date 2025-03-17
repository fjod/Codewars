mod data;
use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {  //     294 / 296 testcases passed
    let result = add_binary(
        String::from("11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"),
         String::from("1"));
    println!("result {:?}", result);
} 

pub fn add_binary(a: String, b: String) -> String {
        let s1 = convert_to_binary(&a);
        let s2 = convert_to_binary(&b);
        int_to_binary(s1 + s2)
}

fn convert_to_binary(input: &str) -> u128{
    let mut result = 0;
    let mut n = 0;
    for c in input.chars().rev() {
        if c == '1' {
            result += 2u128.pow(n);
        }
        n += 1;
    }
    result
}

fn int_to_binary(input: u128) -> String {
    if input == 0 {
        return "0".to_string();
    }
    let mut result = String::new();
    let mut n = input;
    while n > 0 {
        let remainder = n % 2;
        result.push_str(&remainder.to_string());
        n = n / 2;
    }
    result.chars().rev().collect()
}