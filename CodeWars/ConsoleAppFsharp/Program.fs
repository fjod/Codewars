open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 // possibly can be rewritten with using Seq functions
    let isAnagram (s:string) (t:string)=
        let dict = Dictionary<char,int>()
        let addToDict (c : char) = 
            if dict.ContainsKey c then dict[c] <- dict[c] + 1
            else dict.Add(c,1)
            ()
        let removeFromDict (c : char) =
            dict[c] <- dict[c] - 1
            ()    
        for c in s do addToDict c
        
        let allCharsAreFound = s.ToCharArray()
                               |> Array.map (fun c -> dict.ContainsKey c)
                               |> Array.filter (fun r -> r = false)
                               |> Array.length = 0
        for c in t do removeFromDict c
        
        allCharsAreFound && dict.Values |> Seq.forall (fun v -> v = 0)

  
    printfn "Hello from F#1"
