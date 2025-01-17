fn main() {
    let str = String::from("");
    let test = score_of_string(str);
    println!("result is {test}")
}

pub fn score_of_string(s: String) -> i32 {
    let mut score = 0;
    let mut chars = s.chars();

    //if let Some(first) = chars.next() is a concise way to handle the Option
    // returned by chars.next() and bind the value to first if it exists.
    if let Some(first) = chars.next() {
        let mut prev = first as i32;

        for current in chars {
            let current_val = current as i32;
            score += (prev - current_val).abs();
            prev = current_val;
        }
    }



    score
}
