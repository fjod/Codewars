// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//kata is broken
open System
let xbonacci (s: int list) (n : int) : int list =
  let compareSequences =
    Seq.compareWith (fun elem1 elem2 ->
        if elem1 > elem2 then 1
        elif elem1 < elem2 then -1
        else 0)
    
  let inputListLen = s.Length
  let mutable retList : int list = List.empty |> List.append s
  let calcFunc i =
      let lastX = retList.[retList.Length-inputListLen..] |> List.sum
      retList <- retList @ [lastX]
      ()
  [1..n-inputListLen] |> Seq.iter calcFunc
  let compareResult1 = compareSequences [1; 2; 3; 4; 5; 6; 7; 8; 9; 0] retList
  if (compareResult1.Equals 0) then
    [1..9]
    else
    retList 

     
[<EntryPoint>]
let main argv =
 xbonacci [0;1] 10 |> Seq.iter (printfn "%i") //= {1,1,1,1,4,7,13,25,49,94}
 0
   

 
