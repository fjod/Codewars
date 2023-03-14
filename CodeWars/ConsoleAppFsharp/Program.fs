open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     let subset (num:int[]) =        
         let rec backTrack (subset:int list) (ret : int list list) (level:int)=
             if level >= num.Length then
                let copy = subset.GetSlice(Some 0, Some 3)
                copy :: ret
             else
                 let ret2 = backTrack ( (level+1) :: subset) ret (level + 1)
                 backTrack subset ret2 (level + 1)         
         backTrack [] [] 0
     
     let test = subset [|1;2;3|]
     printfn "Hello from F#1"
