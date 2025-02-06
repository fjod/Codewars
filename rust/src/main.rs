fn main() {
    let test = get_sneaky_numbers(vec![7,1,5,4,3,4,6,0,9,5,8,2]);
    println!("Amount of pairs {:?}", test);
}

pub fn get_sneaky_numbers(nums: Vec<i32>) -> Vec<i32> {
    let mut unique_numbers: std::collections::HashSet<i32> = std::collections::HashSet::new();
    for i in 0..nums.len() {
        for j in i+1..nums.len(){
            if nums[i] == nums[j]
                { unique_numbers.insert(nums[i]); }
        }
    }
    let mut sneaky_numbers: Vec<i32> = Vec::with_capacity(2);
    for n in unique_numbers {
        sneaky_numbers.push(n)
    }
    sneaky_numbers
}