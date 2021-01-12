// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp



let duplicateCount (text : string) : int =
    let dict = System.Collections.Generic.Dictionary<char,int>()
    let checkChar c =       
        if (dict.ContainsKey c)
            then
            dict.[c] <- dict.[c] + 1            
            else
            dict.Add(c,1)          
     
    text.ToUpperInvariant() |> Seq.iter checkChar 
    dict |> Seq.fold (fun acc v-> if (v.Value>1) then acc+1 else acc) 0
    
   


[<EntryPoint>]
let main argv =
    
   duplicateCount "aabbcde"|> printfn "%i" 
   0 // return an integer exit code
   
//let duplicateCount (text : string) : int =
//    text.ToLower()
//    |> Seq.countBy id
//    |> Seq.filter (fun (_, count) -> count > 1)
//    |> Seq.length   