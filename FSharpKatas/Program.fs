let deleteNth order max_e =
    let howManyTimesThisNumIsInList (l:int list) (num:int) =
        l |> List.where (fun i -> System.Math.Abs(i - num) < 1) |> List.length
    let mutable retList = List.empty
    order |> List.iter (fun i ->
        let gotItAlready = howManyTimesThisNumIsInList retList i
        if (gotItAlready < max_e) then retList <- retList @ [i]        
        )
    retList
    // TODO

[<EntryPoint>]
let main argv =
    deleteNth [1;1;3;3;7;2;2;2;2] 3 |> List.iter (fun i-> printfn "%i" i)
    0
   
//let deleteNth order max_e =
//    let res = new ResizeArray<int>()
//    for i in order do
//        let itemCounts =
//            res
//            |> Seq.filter ((=) i)
//            |> Seq.length
//        if itemCounts < max_e then
//            res.Add i
//    Seq.toList res
