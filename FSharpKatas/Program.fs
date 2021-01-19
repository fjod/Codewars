// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
//kata is broken
open System

//v1 slow, v2 big
let race (v1:int) (v2:int) (g:int) =
    // your code
    let speedInSecondsV1 =  (double v1)/60.0/60.0
    let speedInSecondsV2 =  (double v2)/60.0/60.0      
    let distanceDiff = double g
    if (speedInSecondsV2 - speedInSecondsV1 <= 0.0) then
        None
    else
        let infSeconds = Seq.initInfinite id
        let calcDistanceForSecond second (speed:double) : double = second*speed       
        let ret  = infSeconds |> Seq.takeWhile (fun s ->
            let diffInDistance = distanceDiff + calcDistanceForSecond (double s) speedInSecondsV1 -  calcDistanceForSecond (double s) speedInSecondsV2
            if (diffInDistance < -0.0001) then               
                false
             else true            
            )  
        let span = System.TimeSpan.FromSeconds (float (Seq.length ret) - 1.0)
        Some [int span.TotalHours;span.Minutes;span.Seconds]
        
        
   

     
[<EntryPoint>]
let main argv =    
    let (a:int list option) = race 80 100 40
    match a with
    | Some value -> List.iter  (printfn "%i") value 
    | None -> printfn "test"
    0
   
//My math problems can be solved with bruteforce!!
 
//let race v1 v2 g =
//    if v1 >= v2
//    then None
//    else
//        let t = System.TimeSpan.FromHours (float g / float (v2 - v1))
//        Some [int t.TotalHours; t.Minutes; t.Seconds]