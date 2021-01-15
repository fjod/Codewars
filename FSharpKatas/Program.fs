// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
let inline findOdd (numbers: int list) =
   let isEven x = (x % 2) = 0
   let isOdd x = isEven x = false
   numbers
           |> Seq.groupBy id
           |> Seq.map (fun n -> (fst n, Seq.length (snd n)))
           |> Seq.find (fun m -> isOdd (snd m))
           |> fst
 
    
[<EntryPoint>]
let main argv =
  

   [20; 1; -1; 2; -2; 3; 3; 5; 5; 1; 2; 4; 20; 4; -1; -2; 5] |> findOdd |> printfn "%i"
   
   0 // return an integer exit code
   
//  let inline findOdd numbers = 
//  numbers
//  |> Seq.countBy id
//  |> Seq.find (fun (_, count) -> count % 2 = 1)
//  |> fst
//   


