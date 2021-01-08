// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

//I misunderstood the task; this is written to calc sum for all tree; while we need the sum for only one row :/
let kataFunc (n:int) =
    let mutable sum = 0
    let mutable prevEnd = 0
    let getDigitsListForRow (row:int) (start:int) =
        match row with 
            | 1 -> [1]
            | _ -> [start..2..start+2*(row-1)]
            
    let calcAndSave (input:int) : unit =       
        if input.Equals 1 then
            sum <- 1
            prevEnd <- 1
        else
           let thisStart = prevEnd + 2
           let prevList = getDigitsListForRow input thisStart
           prevEnd <- List.last prevList
           sum <- List.sum prevList
           ()      
       
    [1..n] |> List.iter  calcAndSave
    sum
    

[<EntryPoint>]
let main argv =
   
   kataFunc 3 |> printfn "%i" 
   
   0 // return an integer exit code