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
     
     let permute (num:int[])=
         let rec backTrack (num:int[]) (ret : int list list) (level:int)=
             if num.Length = level then
                    let lst = num |> Array.toList 
                    lst :: ret
                else
                    let lst = [level..num.Length]
                    for i in lst do
                          let numsI = num[i]
                          let numLevel = num[level]
                          num[level] <- numsI
                          num[i] <- numLevel                       
                          backTrack num ret (level + 1) |> ignore
                          num[level] <- numLevel
                          num[i] <- numsI           
                    ret
         backTrack num [] 0 
     
     let test = subset [|1;2;3|]
     printfn "Hello from F#1"
