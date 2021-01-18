// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//kata is broken
open System
let rec digitalRoot (n:int) =      
    let res = n.ToString()           
              |> Seq.map (fun i-> (System.Int32.Parse(i.ToString())))
              |> Seq.sum
    
    match res.ToString().Length with
    | 1 -> res
    | _ -> digitalRoot res
   

     
[<EntryPoint>]
let main argv =
    digitalRoot 942 |> printfn "%i"
    0
   

 
