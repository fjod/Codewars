// For more information see https://aka.ms/fsharp-console-apps

open System

printfn "Hello from F#"

let rec revSpan (s : Span<char>) =
    match s.Length with
        | 1
        | 0 -> ignore
        | _ ->
            let left = s[0]
            let right = s[s.Length - 1]
            s[0] <- right
            s[s.Length - 1] <- left
            let span = s.Slice(1,s.Length - 2)
            revSpan(span)
            
            
let test = [|'h'; 'e'; 'l'; 'l'; 'o'|]
revSpan(test.AsSpan()) |> ignore
revSpan(test.AsSpan()) |> ignore
    