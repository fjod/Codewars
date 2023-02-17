open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
    let LongestConsecutive(nums:int[]) =
        let set = HashSet<int>(nums.Length)
        nums |> Array.iter (fun i -> set.Add(i) |> ignore)
        let visited = HashSet<int>(nums.Length)
        (1, nums) ||> Array.fold (fun max i ->
            if visited.Contains(i) then max
            else
                visited.Add(i) |> ignore               
                let rec addNext (next:int) (acc:int) : int =
                    if set.Contains(next) then
                        visited.Add(next) |> ignore
                        acc + addNext (next + 1) (acc + 1)
                        else
                        0
                       
                let rec addPrev (prev:int) (acc:int) : int =
                    if set.Contains(prev) then
                        visited.Add(prev) |> ignore
                        acc + addPrev (prev - 1) (acc + 1)
                        else
                        0
                let next = addNext (i + 1) 0
                let prev = addPrev (i - 1) 0
                let total = next + prev + 1
                
                Math.Max(max, total)            
            ) 
        
        
    let test = LongestConsecutive [|100; 4; 200; 1; 3; 2|]
    printfn "Hello from F#1"
