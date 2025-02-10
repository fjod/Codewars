fn main() {
    let test = two_sum(vec![3,2,4] ,6);
    println!("result {:?}", test);
}

pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
    let mut dict = std::collections::HashMap::with_capacity(nums.len());
    dict.insert(nums[0], 0);
    for i in 1..nums.len() {
        let current = nums[i];
        let diff = target - current;
        if dict.contains_key(&diff) {
            return vec![dict[&diff], i as i32];
        }
        else {
            dict.insert(nums[i], i as i32);
        }
    }
    vec![]
}