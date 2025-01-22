fn main() {
    let test = convert_temperature(36.5);
    println!("All elements: {:?}", test);
}

pub fn convert_temperature(celsius: f64) -> Vec<f64> {
    let mut result: Vec<f64> = Vec::with_capacity(2);
    result.push(celsius + 273.15);
    result.push(celsius * 1.8 + 32.0);
    result
}
