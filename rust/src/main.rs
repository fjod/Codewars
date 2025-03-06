mod data;
use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let str1 = String::from("sadbutsad");
    let str2 = String::from("sad");
    let result = str_str(str1, str2);
    println!("result {:?}", result);
}

pub fn str_str(haystack: String, needle: String) -> i32 {
        let needle_len = needle.len();
        if needle_len == 0 {
            return 0;
        }
        if needle_len > haystack.len() {
            return -1;
        }

        let haystack_len = haystack.len();
        for (index, _) in haystack.chars().enumerate() {
            if (index + needle_len) > haystack_len {
                return -1;
            }
            let sub_hay_stack = &haystack[index..index+needle_len];
            if sub_hay_stack == needle {
                return index as i32;
            }          
        }
        return -1   
}