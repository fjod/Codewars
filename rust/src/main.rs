mod data;
use data::list::ListNode; // Refers to ListNode in src/data/data.rs

fn main() {
    let mut node1 = ListNode::new(1);
    let mut insert = vec![1,1,1,2,2,3];
    let result = remove_duplicates(&mut insert);
    println!("result {:?} {:?}", insert, result);
}

pub fn remove_duplicates(nums: &mut Vec<i32>) -> i32 {
    let len = nums.len();
    if len <= 1 {
        return len as i32;
    }
    let mut total_uniques = 1;
    let mut place_for_next: Option<usize> = None;

    for i in 0..len - 1 {
        let cur = nums[i];
        let next = nums[i+1];
        if cur == next {
            if place_for_next == None // сохранить первое место появления дубликата
            {
                place_for_next = Some(i+1);
                continue;
            }
        }
        else {
                // если встретили новую цифру и до этого запоминали адрес первого дубликата
                if let Some(place) = place_for_next {
                    nums[place] = next;
                    place_for_next = Some(place + 1); // запоминаем где следующее место для дубликата
                }
                total_uniques = total_uniques + 1;
        }
    }
    total_uniques
}

