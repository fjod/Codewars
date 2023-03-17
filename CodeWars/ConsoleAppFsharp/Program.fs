open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

     let maxSub (arr:int[]) =
         let rec calcSum (arr:int[]) (index:int) (max:int) (sum:int) =
             if (index = arr.Length) then max
             else
                 let curSum = sum + arr[index]
                 let curSum = Math.Max(curSum, 0)
                 let maxSub = Math.Max(curSum, max)
                 calcSum arr (index+1) maxSub curSum
         calcSum arr 0 arr[0] 0
     
     let test = maxSub [|-2;1;-3;4;-1;2;1;-5;4|]
     printfn "Hello from F#1"
