open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    
    let robTopDown(houses: int list) =
        let dict = new Dictionary<int, int>()
        dict[0] <- houses[0]
        dict[1] <- max houses[0] houses[1]
        0
    
    let rec rob(house:int, dict: Dictionary<int, int>, houses: int list) =
        if dict.ContainsKey(house) then dict[house]
        else
            let prev = dict[house-1]
            let prevPrevAndCurrent = dict[house-2] + houses[house]
            dict[house] <- max prev prevPrevAndCurrent
            dict[house]
        
    let robBotUp(houses: int list) =
        let robVals = Array.init houses.Length (fun _ -> 0)
        robVals[0] <- houses[0]
        robVals[1] <- max houses[0] houses[1]
        for i in 2..(houses.Length - 1) do
            let prev = robVals[i-1]
            let prevPrevAndCurrent = robVals[i-2] + houses[i]
            robVals[i] <- max prev prevPrevAndCurrent
        Array.max robVals
    
    printfn "Hello from F#1"
