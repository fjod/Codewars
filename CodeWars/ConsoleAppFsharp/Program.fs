open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     let IsValid (s:string) =
        let Stack = System.Collections.Generic.Stack<char>()
        let rec workOnString (index:int) =
            if (index = s.Length) then true
            else
            let ch = s[index]
            match ch with 
                | '(' | '[' | '{' ->
                    Stack.Push(ch)
                    workOnString (index + 1)
                | ')' when Stack.Count > 0 && Stack.Peek() = '(' ->
                    Stack.Pop() |> ignore
                    workOnString (index + 1)
                | ']' when Stack.Count > 0 && Stack.Peek() = '[' ->
                    Stack.Pop() |> ignore
                    workOnString (index + 1)
                | '}' when Stack.Count > 0 && Stack.Peek() = '{' ->
                    Stack.Pop() |> ignore
                    workOnString (index + 1)
                | _ -> false    
        let work = workOnString 0
        work &&  Stack.Count = 0
     let test = IsValid "}(}"
     printfn "Hello from F#1"
