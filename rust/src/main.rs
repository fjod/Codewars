fn main() {
    let vec = vec![5,0,1,2,3,4];
    let test = build_array(vec);
    println!("All elements: {:?}", test);
}

pub fn build_array(nums: Vec<i32>) -> Vec<i32> {
   let mut result: Vec<i32> = Vec::with_capacity(nums.len());
    for i in 0..nums.len() {
        let index = nums[i] as usize;
        result.push(nums[index]);
    }
    result
}
