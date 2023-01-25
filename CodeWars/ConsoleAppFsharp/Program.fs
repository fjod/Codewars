open System
open System.Collections.Generic
open TreeNodeDef

module ConsoleAppFsharp =

    let calcLis(arr: int[]) =
        let mutable lisValues = Array.init arr.Length (fun _ -> 1)
        for i in 1..arr.Length-1 do
            for j in 0..i do
                if (arr[i] > arr[j] && lisValues[i] < lisValues[j] + 1) // I cant understand this hack
                    then lisValues[i] <- lisValues[j] + 1
                    else ()        
        Array.max lisValues
        
    let testLis = [|10; 22; 9; 33|]
    let z = calcLis testLis
    printfn "Hello from F#1"
