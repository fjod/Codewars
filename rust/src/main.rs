mod data;
use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let v = String::from("day    ");
    let result = length_of_last_word(v);
    println!("result {:?}", result);
}
 // really bad solution
pub fn length_of_last_word(s: String) -> i32 {
        let s2 = trim_end(&s);
        let len = s2.len();   
        let mut right = len;   
        let mut left : Option<usize> = None;
        let mut any_space = false;
        for (i, current) in s2.chars().rev().enumerate() {
            println!("result {:?}", current);
            match current {
                ' ' => {
                    if let Some(leftn) = left {
                        return (right - leftn) as i32;
                    }
                    else {
                        right = len - 1 - i;
                    }
                    any_space = true;
                },
                _ => {                 
                        left = Some(len - 1 - i);                   
                }
            }
        }
        if any_space {
            return len as i32 - right as i32
        }
        return len as i32;
        
}

pub fn  trim_end(s: &String) -> &str{
    let mut last_space: Option<usize> = None;
    for (i, current) in s.chars().rev().enumerate() {
        match current {
            ' ' => {
                last_space = Some(i);
              
            },
            _ => {   
                if let Some(lp) = last_space {
                    return &s[..s.len() - lp - 1];
                }
                return &s                       
            }
        }
    }
    return &s          
}