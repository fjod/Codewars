fn main() {
    let vec = vec![1, 2, 3];
    let test = get_concatenation(vec);
    println!("All elements: {:?}", test);
}

pub fn get_concatenation(mut nums: Vec<i32>) -> Vec<i32> {
  /*  let mut vec: Vec<i32> = Vec::with_capacity(nums.len() * 2);
    for _ in 0..2 {
        for i in 0..nums.len() {
            vec.push(nums[i])
        }
    }
    vec*/
    let len = nums.len();
    for i in 0..len {
        nums.push(nums[i])
    }
    nums
}
