// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System  
let kataFunc (step:int) (lowerBound:int) (upperBound:int) =
    let isPrime n =
      let sqrt' = (float >> sqrt >> int) n // square root of integer
      [ 2 .. sqrt' ] // all numbers from 2 to sqrt'
      |> List.forall (fun x -> n % x <> 0) // no divisors
    let ifStepIsEqual (a:int) = a.Equals(step)
    let getStepForTwoPrimes ((a:int),(b:int)) = Math.Abs(a-b) |> ifStepIsEqual   
    
    let primes = [lowerBound..upperBound] |> List.filter isPrime |> List.pairwise 
    let firstPair = List.find getStepForTwoPrimes primes
    let a = fst firstPair
    let b = snd firstPair    
    [Int64.Parse(a.ToString());Int64.Parse(b.ToString())]
    ///home/codewarrior/program.fsx(37,25): error FS0001: This expression was expected to have type
    //'int'     
    //but here has type
    //  'int64'
    // I was not able to pass test on codewars site because of this error^. 
[<EntryPoint>]
let main argv =
    let checkNumberForPrimeAndPrint (list: int64 list) =
        printf "First pair is -> %i %i" list.[0] list.[1]      
    kataFunc 4 130 200 |>    checkNumberForPrimeAndPrint  
   
    0 // return an integer exit code