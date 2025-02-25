fn main() {
    let test = is_valid(String::from("()"));

    println!("result {:?}", test);
}

pub fn is_valid(s: String) -> bool {
    if s.len() == 0 {
        return true;
    }
    if s.len() % 2 != 0 {
        return false;
    }
    let mut v: Vec<char> = Vec::with_capacity(s.len());

    let pairs = [('(', ')'),('{', '}'),('[', ']')];
    for c in s.chars() {
        // check if c is open bracket
        let is_open = check_open(&pairs, &c);
        if is_open {
            v.push(c);
        }
        else {
            // it is closed bracket, pop last one
            match v.pop() {
                None => {
                    // Stack is empty - invalid anyway
                    return false;
                }
                Some(last) => {
                    // ')' is current, so '(' must be prev
                    let prev_ok = check_prev(last, c, &pairs);
                    if !prev_ok {
                        return false;
                    }
                }
            }
        }
    }

    // if stack is not empty - there are some open brackets that were not closed
    v.len() == 0
}

fn check_prev(prev: char, current: char, p0: &[(char, char); 3]) -> bool {
    p0.iter().find(|&&(start, end)| start == prev && end == current).is_some()
}

fn check_open(p0: &[(char, char); 3], p1: &char) -> bool {
    p0.iter().find(|(x, _)| x == p1).is_some()
}