open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
    let topKFreq(nums:int[]) (k:int) =
        nums
        |> Array.groupBy id
        |> Array.map (fun f -> (fst f, (snd f).Length))
        |> Array.sortByDescending snd
        |> Array.take k
        |> Array.map fst
   
    printfn "Hello from F#1"
