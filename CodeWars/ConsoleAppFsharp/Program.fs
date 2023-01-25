open System
open System.Collections.Generic
open TreeNodeDef

module ConsoleAppFsharp =

    let Dict = Dictionary<int,int>()
    do
        Dict[0] <- 0
        Dict[1] <- 1
        Dict[2] <- 2
    let rec climbStairs(n:int) =
       if Dict.ContainsKey(n) then Dict[n]
       else
           let step1 = climbStairs(n-1)
           let step2 = climbStairs(n-2)
           Dict[n] <- step1+step2
           Dict[n]        
 
    let z = climbStairs 5
    printfn "Hello from F#1"
