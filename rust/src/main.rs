fn main() {
    let test = difference_of_sums(10 ,3);
    println!("result {:?}", test);
}

pub fn difference_of_sums(n: i32, m: i32) -> i32 {
    let mut sum1 = 0;
    let mut sum2 = 0;
    for i in 1..n + 1 {
        if i % m == 0 {
            sum2 += i;
        }
        else {
            sum1 += i;
        }
    }
    sum1 - sum2
}