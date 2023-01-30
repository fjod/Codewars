open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

     let rec innerArrange(stair:int, number:int) =
        match number - stair with
         | 0 -> stair
         | v when v < 0 -> stair - 1
         | v -> innerArrange (v - stair, stair + 1)
     let arrangeCoins (n:int) =
        innerArrange (1, n)
     
   
   
        
     let test = arrangeCoins 5
     printfn "Hello from F#1"
