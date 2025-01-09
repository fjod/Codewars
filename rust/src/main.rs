fn main() {
    let jewels = String::from("aA");
    let stones = String::from("aAAbbbb");
    let test = num_jewels_in_stones(jewels, stones);
    println!("result is {test}")
}

pub fn num_jewels_in_stones(jewels: String, stones: String) -> i32 {
    let mut c = 0;
    for stone in (&stones).chars() {
        if  jewels.contains(stone) {
            c += 1;
        }
    }
    c
}
