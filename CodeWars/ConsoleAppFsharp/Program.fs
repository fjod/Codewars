open System
open System.Collections.Generic
open TreeNodeDef

module ConsoleAppFsharp =

    let dict = Dictionary<Tuple<int,int>, int>()
    do
        dict.Add((0,0), 1)
        dict.Add((1,0), 1)
        dict.Add((1,1), 1)
    let rec calcTriangleValue(v:Tuple<int,int>)=
        let dictVal = dict.ContainsKey v
        if dictVal then dict[v]
        else
            let left = fst v // row
            let right = snd v // col
            match (left, right) with
                | _, 0 -> 1
                | _ ,_ when left = right  -> 1
                | l, r ->
                    let v = calcTriangleValue((l-1, r-1)) + calcTriangleValue(l-1 ,r)
                    dict.Add((l,r), v)
                    v
    let pascal(row:int) =        
        [0..row] |> List.map (fun i -> calcTriangleValue(row, i))
        
    let test = pascal 4
    printfn "Hello from F#1"
