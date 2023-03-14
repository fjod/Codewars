open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     let subset (num:int[]) =        
         let rec backTrack (subset:int list) (ret : int list list) (level:int)=
             if level >= num.Length then
                subset :: ret
             else
                 let l1 = level + 1
                 let ret2 = backTrack (l1 :: subset) ret l1
                 backTrack subset ret2 l1
         backTrack [] [] 0
     
     let test = subset [|1;2;3|]
     printfn "Hello from F#1"
