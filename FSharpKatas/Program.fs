
open System

let findEvenIndex (items : int array) =
    let itemsLen = Array.length items 
    let checkArray (index:int) =         
        let one = Array.sum items.[..index]
        let two = Array.sum items.[index..]
        not (one.Equals two)        
      
    let calcLen = [0..items.Length] |> Seq.takeWhile (checkArray) |> Seq.length    
    if calcLen.Equals (itemsLen + 1) then -1
    else  calcLen
        
       
//this does not pass codewars test when it should return -1
//while works on my pc
     
[<EntryPoint>]
let main argv =    
    let q = [|1; -1; -1; -2|]
    findEvenIndex q |> printfn "%i"
    0
   
