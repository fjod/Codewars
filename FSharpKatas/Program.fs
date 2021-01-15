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
 
type Request = {name:string; email:string}

let (>>=) twoTrackInput switchFunction = 
    Option.bind switchFunction twoTrackInput 
let validate1 input =
   if input.name = "" then None  else Some input
let validate2 input =
   if input.name.Length > 50 then None else Some input
let validate3 input =
   if input.email = "" then None  else Some input        
let combinedValidation x =
    // connect the two-tracks together   
   x |> validate1 >>= validate2  >>=  validate3
   
//https://fsharpforfunandprofit.com/posts/recipe-part2/
    
[<EntryPoint>]
let main argv =
   let testRequest = {name = "QQseg"; email = " "}
   combinedValidation testRequest |> ignore   
   
   let test = Some 1 |> Option.map (fun i-> i.ToString())
   let test2 = Some 1 |> Option.bind (fun i-> Some (i.ToString()))
   test.Value.Equals test2.Value |> printfn "%b" //true
   
   0 // return an integer exit code
   
//  let inline findOdd numbers = 
//  numbers
//  |> Seq.countBy id
//  |> Seq.find (fun (_, count) -> count % 2 = 1)
//  |> fst
//   


