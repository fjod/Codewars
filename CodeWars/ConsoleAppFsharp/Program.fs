open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    let solutions = List<string>()
    
    let rec genParensInner (arr:char[]) (index:int) (leftRem:int) (rightRem:int) =
        if (leftRem = 0 && rightRem =0) then
            solutions.Add(arr.AsSpan().ToString())
            ()
        else if leftRem > 0 then                
                    arr[index] <- '('
                    genParensInner arr (index + 1) (leftRem - 1) rightRem              
            else if rightRem > 0 && rightRem > leftRem then
                    arr[index] <- ')'
                    genParensInner arr (index + 1) leftRem (rightRem - 1)
            else ()
            
    let generateParens (n :int) =
        let arr = Array.init (n*2) (fun _ -> '0')
        genParensInner arr 0 3 3
        solutions
    

does not work
    let test = generateParens 3
    printfn "Hello from F#1"
