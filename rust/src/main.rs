fn main() {
    let vec_mut = vec![4,1,2,1,2];
    let test = single_number(vec_mut);
    println!("result is {test}")
}

pub fn single_number(nums: Vec<i32>) -> i32 {
    let mut map = std::collections::HashMap::new();
    for item in &nums {
        map.entry(item)
            .and_modify(|counter| *counter += 1)
            .or_insert(1);
    }

    for (&key, &value) in &map {
        if value == 1 {
            return *key;
        }
    }
    -1
}
