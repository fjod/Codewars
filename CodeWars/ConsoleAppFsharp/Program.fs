open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
    let twoSum(nums:int[]) (target:int) =
        let dict = Dictionary<int, int>()
        nums |> Array.mapi (fun i n ->
            let left = target - n
            if dict.ContainsKey(left) then Some (i, dict[left])
            else                
                if dict.ContainsKey(n) = false then dict.Add(n, i)
                None            
            ) |> Array.choose id |> Array.take 1 |> Array.map (fun r -> [|fst r; snd r|])
   
        
        
    
    let test = twoSum [|2;7;11;15|] 9
    let q = test[0]
    printfn "Hello from F#1"
