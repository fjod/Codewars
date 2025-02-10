fn main() {
    let test = is_palindrome(9999);
    println!("result {:?}", test);
}

pub fn is_palindrome(x: i32) -> bool {
    let mut current_x = x;
    let ten : i32 = 10;
    let digits = count_digits(x);
    if (x < 0){
        return false;
    }
    if (x == 0){
        return true
    }
    let half = digits / 2;
    let mut pow = ten.pow(digits - 1); // 100?
    for _i in 0..half {
        let fst_digit = current_x / pow;
        let last_digit = last_digit(current_x);
        if fst_digit != last_digit {
            return false;
        }
        current_x = current_x - fst_digit * pow; // remove first digit
        current_x = current_x / 10; // remove last digit
        pow = pow / 100;
    }
    true
}

fn count_digits(num: i32) -> u32 {
    // Handle the case for zero separately
    if num == 0 {
        return 1;
    }

    // Convert the number to its absolute value
    let mut n = num.abs();
    let mut count = 0;

    // Count the digits
    while n > 0 {
        count += 1;
        n /= 10;
    }

    count
}

fn last_digit(num: i32) -> i32 {
    // Ensure the number is positive for the modulus operation
    let abs_num = num.abs();
    abs_num % 10
}