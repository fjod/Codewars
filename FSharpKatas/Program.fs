
open System
open System.Numerics

//F(n) = F(n-1) + F(n-2)
//F(1) = 1
//F(2) = 1

      
let perimeter (n: BigInteger): BigInteger =
    
    let lookup = Array.create (int n + 10) (BigInteger 0)
    
    let rec fib = fun (x:BigInteger) ->
        match x with
        | (var) when (var = 1I) -> 1I
        | (var) when (var = 2I) -> 2I        
        | x ->
            match lookup.[int x] with
            | (var) when (var = 0I) ->
                lookup.[int x] <- fib(x-1I) + fib(x-2I)
                lookup.[int x]
            | x -> x
    
    let a = [1I..n] |> List.map fib |> List.sum
    a * 4I + 4I
  
  

[<EntryPoint>]
let main argv =
    perimeter (BigInteger 20) |> Console.WriteLine 
    0
   
//let perimeter (n: BigInteger): BigInteger =
//  (1I, 1I)
//  |> Seq.unfold (fun (first, second) -> Some(first, (second, first + second)))
//  |> Seq.take (int n + 1)
//  |> Seq.sum
//  |> (*) 4I