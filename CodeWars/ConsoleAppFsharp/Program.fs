open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
    let generateCoins (coins:int[]) (amount:int) =
        
        let dp = Array.init (amount + 1) (fun _ -> 0)
        dp[0] <- 1
        
        for coin in coins do
            let interval = [coin..1..amount]
            for x in interval do
                dp[x] <-  dp[x] + dp[x - coin]
        
        dp[amount]


    let test = generateCoins  [|1;2;5|] 5
    printfn "Hello from F#1"
