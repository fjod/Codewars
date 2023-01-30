open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    let rec solve(p1: int, p2 : int, dp: int[][], t1:string, t2 :string) =
        match (p1, p2) with
           | p1, _ when p1 = t1.Length -> 0
           | _, p2 when p2 = t2.Length -> 0
           | _ ->
               if dp[p1][p2] <> -1 then dp[p1][p2]
               else
                   let ignoreFirst = solve(p1+1, p2, dp, t1, t2)
                   let mutable takeFirst = 0
                   let pos = t2.IndexOf(t1[p1], p2)
                   if pos <> -1 then
                       takeFirst <- 1 + solve(p1 + 1, p2 + 1, dp, t1, t2)
                   else takeFirst <- 0
                   dp[p1][p2] <- Math.Max(ignoreFirst, takeFirst)
                   dp[p1][p2]
               
    let lcs(t1:string, t2:string) =
        let dp = Array.init t1.Length (fun _ -> Array.init t2.Length (fun _ -> -1))
        solve(0, 0, dp, t1, t2) |> ignore
        dp[0][0]
    
    let ret = lcs ("ace", "abcde")
    printfn "Hello from F#1"
