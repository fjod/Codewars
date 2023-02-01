open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

     let coinChange(coins:int[], amount:int) =
         let dp = Array.init (amount+1) (fun _ -> Int32.MaxValue)
         dp[0] <- 0
         for currentAmount in 1..amount do
             for coin in coins do                 
                 if coin <= currentAmount then
                     dp[currentAmount] <- Math.Min(dp[currentAmount], dp[currentAmount - coin] + 1)
                  
         if (dp[amount] > amount) then -1 else dp[amount]   
        
     let test1 = coinChange( [|1;2;5|], 11)
     let test2 = coinChange( [|186;419;83;408|], 6249) // this this fail because int must be changed to long
     printfn "Hello from F#1"
