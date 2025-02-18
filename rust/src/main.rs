fn main() {
    let strs = vec![ String::from("flower")
    , String::from("flight"),
    String::from("flow"),];
    let test = longest_common_prefix(strs);


    println!("result {:?}", test);
}

pub fn longest_common_prefix(strs: Vec<String>) -> String {
    let min_len_index = find_shortest_string(&strs);
    let shortest_str = strs.get(min_len_index).unwrap();
    for i in 0..shortest_str.len() {
        let current_char_short = shortest_str.chars().nth(i).unwrap();
        for j in 0..strs.len() {
            if j == min_len_index {
                continue;
            }
            let current_char_other = strs.get(j).unwrap().chars().nth(i).unwrap();
            if current_char_short != current_char_other {
                return String::from(&shortest_str[0..i]);
            }
        }
    }

    strs.get(min_len_index).unwrap().to_string()
}

pub fn find_shortest_string(strs: &Vec<String>) -> usize {
    let mut len : usize = 99999999;
    let mut index : usize = 0;
    for i in 0..strs.len() {
        let current_str = strs[i].len();
        if current_str < len {
            len = current_str;
            index = i
        }
    }
    index
}