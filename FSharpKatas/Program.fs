// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
let findNb(input: uint64): int =
       
   let mutable acc:uint64 = 0UL
   let mutable index = 0
   let incrementAcc i =
       acc <- acc + pown (uint64 i) 3
       acc
   let inf = Seq.initInfinite (incrementAcc)
                                        |> Seq.takeWhile (fun i ->
                                            index <- index + 1
                                            i <= input)
   if (Seq.last inf).Equals input then index-2
   else -1  
  

[<EntryPoint>]
let main argv =
  

   findNb(1071225UL)  |> printfn "%i"
   
   0 // return an integer exit code
   
   // I could change parsing to just "int" and it works the same
   


