open TreeNodeDef

module ConsoleAppFsharp =

    type FizzBuzz =
        | Fizz
        | Buzz
        | FizzBuzz
        | Number of int

    let checkValue(v : int) =
        let div3 = (v % 3) = 0
        let div5 = (v % 5) = 0
        match (div3, div5) with
            | true, false -> Fizz
            | false, true -> Buzz
            | true, true -> FizzBuzz
            | _ -> Number v
            
    let printFb( f : FizzBuzz) =
        match f with           
           | Number v -> v.ToString()
           | _ -> f.ToString()
    let generateFb (limit : int) =       
        {1..limit} |> Seq.map checkValue|> Seq.map printFb |> Seq.map (fun v -> printf $"%A{v},") |> Seq.toList
        
    generateFb 100
    printfn "Hello from F#1"
