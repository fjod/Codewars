// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


let kataFunc (n:int) =   
   
   let isMultipleBy (value_3_5:int) (inputNumberToCheck:int) =
     let q = inputNumberToCheck % value_3_5
     q.Equals 0
     
   let isMultipleBy3 i = isMultipleBy 3 i
   let isMultipleBy5 i = isMultipleBy 5 i
   let calculator(acc:int) (value:int)  =
      if value.Equals 0
      then 0
      else
         let is3 = isMultipleBy3 value
         let is5 = isMultipleBy5 value
         match (is3,is5) with
         |true,false -> value+acc
         |false,true -> value+acc
         |true,true -> value+acc
         | _ -> acc
      
   List.fold calculator 0 [0..n-1]
    

[<EntryPoint>]
let main argv =
   
   kataFunc 10 |> printfn "%i" 
   
   0 // return an integer exit code
   
//how it should be solved:
//let solve n = 
//    [3..3..n-1]
//    |> List.append [5..5..n-1]
//    |> Set.ofList
//    |> Set.fold (+) 0

//let solve n = 
//    Seq.init n id
//    |> Seq.filter (fun x -> x%3 = 0 || x%5 = 0)
//    |> Seq.sum