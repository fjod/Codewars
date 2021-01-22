
open System
open System.Text

let rgb (r:int) (g:int) (b:int) =
    let hex = new StringBuilder()
    [r;g;b] |> Seq.map (fun i ->
        match i with
        | (b) when (b >= 0) && (b <= 255) -> byte b
        | (b) when (b > 255) -> byte 255
        | (b) when (b < 0) -> byte 0
        | _ -> byte b
        ) |> Seq.toArray
        |> Seq.iter (fun b -> hex.AppendFormat ("{0:x2}",b)|> ignore)  
    
         
    hex.ToString().ToUpperInvariant()

     
[<EntryPoint>]
let main argv =    
    rgb 148  0  211 |> printfn "%s"
    0
   
// let getRgbValue = max 0 >> min 255