open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    let CheckInclusion (s1:string) (s2:string) =
        let s1Count = Array.create 26 0
        let addToArray (c:char) =
            s1Count[int(c - 'a')] <- s1Count[int(c - 'a')] + 1
            ()
        s1.ToCharArray() |> Array.iter addToArray
        
        let s2Count = Array.create 26 0
        [0..s2.Length] |> List.tryFindIndex (fun i ->
            let s2Char = s2[i]
            s2Count[int(s2Char - 'a')] <- s2Count[int(s2Char - 'a')] + 1
            if (i > s1.Length) then
                 s2Count[int(s2[i - s1.Length] - 'a')] <-  s2Count[int(s2[i - s1.Length] - 'a')] - 1
               else ()
            s1Count = s2Count            
            ) |> Option.isSome
        




    printfn "Hello from F#1"
