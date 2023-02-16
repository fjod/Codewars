open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
    let ProductExceptSelf (nums :int[]) =
        let mutable prefix = 1
        let mutable postfix = 1
        let prefixArray = Array.init nums.Length (fun _ -> 0)
        let postFixArray = Array.init nums.Length (fun _ -> 0)
        for i in 0..nums.Length-1 do
            prefixArray[i] <- prefix
            prefix <- prefix * nums[i]
        for i in nums.Length-1 .. -1 ..0 do
            postfix <- postfix * nums[i]
            postFixArray[i] <- postfix
        let getPrefix (index:int) =
            if index < 0 then 1 else prefixArray[index]
        let getPostfix (index:int) =
            if index = nums.Length then 1 else postFixArray[index]
        Array.init nums.Length id |> Array.map (fun i -> getPrefix(i) * getPostfix(i+1))
        
    let test = ProductExceptSelf [|1;2;3;4|]
    printfn "Hello from F#1"
