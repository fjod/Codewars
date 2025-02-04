fn main() {
    let test = num_identical_pairs(vec![1,2,3,1,1,3]);
    println!("Amount of pairs {:?}", test);
}

pub fn num_identical_pairs(nums: Vec<i32>) -> i32 {
    let mut count = 0;

    for current in 0..nums.len() - 1 {
        for next in current + 1..nums.len() {
            if nums[current] == nums[next] {
                count += 1;
            }
        }
    }
    count
}