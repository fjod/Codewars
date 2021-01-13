// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
let highAndLow (str : string)  =
    let test = str.Split " " |> Array.map (Int32.Parse)    
    (Array.max test).ToString() + " " + (Array.min test).ToString() 
   


[<EntryPoint>]
let main argv =
    
   highAndLow "1 9 -3 4 -5" |> printfn "%s"
   0 // return an integer exit code
   
   // I could change parsing to just "int" and it works the same
   
//let highAndLow (str : string) =
//    str.Split()
//    |> Array.sortBy int
//    |> (fun a -> a |> Array.last, a |> Array.head)
//    ||> sprintf "%s %s"