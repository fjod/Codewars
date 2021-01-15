#r "nuget: FSharp.Data"
open FSharp.Data
//https://fsharpforfunandprofit.com/posts/low-risk-ways-to-use-fsharp-at-work-2/
let queryServer uri queryParams = 
    try
        let response = Http.Request(uri, query=queryParams, silentHttpErrors = true)                
        Some response 
    with
    | :? System.Net.WebException as ex -> None

let sendAlert uri message = 
    // send alert via email, say
    printfn "Error for %s. Message=%O" uri message

let checkServer (uri,queryParams) = 
    match queryServer uri queryParams with
    | Some response -> 
        printfn "Response for %s is %O" uri response.StatusCode 
        if (response.StatusCode <> 200) then
            sendAlert uri response.StatusCode 
    | None -> 
        sendAlert uri "No response"

// test the sites 
let google = "http://google.com", ["q","fsharp"]
let bad = "http://example.bad", []

[google;bad]
|> List.iter checkServer 