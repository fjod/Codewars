open System
open System.Collections.Generic
open ConsoleAppFsharp
open ListNodeDef
open TreeNodeDef
open ConsoleAppFsharp.Node

module ConsoleAppFsharp =

        
     let MostCommonWord (p:string) (banned: string[]) =
         let removeSpecial (s:string) =
             s.ToCharArray()
             |> Array.where (fun f -> "!?',;.".Contains(f) |> not)
             |> Array.fold (fun acc x -> acc + x.ToString()) ""             
       
         p.Replace(',',' ').Split(' ')  
                 |> Array.where (fun f -> String.IsNullOrWhiteSpace(f) |> not)
                 |> Array.map (fun f -> f.ToLower())
                 |> Array.map removeSpecial
                 |> Array.groupBy id
                 |> Array.sortByDescending (fun (_, values) -> values.Length)
                 |> Array.find (fun (key, _) -> (banned |> Array.contains key) |> not)
                 |> fst
                            
         
     let test = MostCommonWord "Bob hit a ball, the hit BALL flew far after it was hit." [|"hit"|]
     printfn "Hello from F#1"
