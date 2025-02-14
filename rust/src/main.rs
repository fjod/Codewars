fn main() {
    let test = roman_to_int(String::from("MCMXCIV"));

    println!("result {:?}", test);
}


pub fn roman_to_int(s: String) -> i32 {
    let mut result : i32 = 0;
    let mut roman_to_numeric: std::collections::HashMap<char, i32> = std::collections::HashMap::new();

    // Insert key-value pairs into the HashMap
    roman_to_numeric.insert('I', 1);
    roman_to_numeric.insert('V', 5);
    roman_to_numeric.insert('X', 10);
    roman_to_numeric.insert('L', 50);
    roman_to_numeric.insert('C', 100);
    roman_to_numeric.insert('D', 500);
    roman_to_numeric.insert('M', 1000);

    let mut substracts: std::collections::HashMap<String, i32> = std::collections::HashMap::new();

    // Insert key-value pairs into the HashMap
    substracts.insert(String::from("IV"), 4);
    substracts.insert(String::from("IX"), 9);
    substracts.insert(String::from("XL"), 40);
    substracts.insert(String::from("XC"), 90);
    substracts.insert(String::from("CD"), 400);
    substracts.insert(String::from("CM"), 900);

    for (i, current) in s.chars().rev().enumerate() {
        let prev = get_prev(&s, i);
        match prev {
            None => result += roman_to_numeric[&current],
            Some(prev) => {
                let two_chars = format!("{}{}", current, prev);
                if substracts.contains_key(&two_chars) {
                    result -= roman_to_numeric[&prev];
                    result += substracts[&two_chars]
                }
                else {
                    // предыдущий символ не подразумевает вычитания, добавляем текущий
                    result += roman_to_numeric[&current]
                }
            }
        }
    }
    result
}

fn get_prev(s: &String, current :  usize) -> Option<char> {
    if current == 0 {
        return None;
    }
    s.chars().rev().nth(current - 1)
}
