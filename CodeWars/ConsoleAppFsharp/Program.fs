open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     let EvalRPN (s:string[]) =
        let calc (sign:string) (v1:int) (v2:int) =
            match sign with
            | "+" -> v1 + v2
            | "-" -> v2 - v1
            | "/" -> v2 / v1
            | "*" -> v1 * v2
        let stack = Stack<int>()
        let rec calcRpn (index:int) (returnValue : int) =
            if (index = s.Length) then returnValue
            else
            let current = s[index]
            match current with
            | "+" | "-" | "/" | "/" ->
                let v1 = stack.Pop()
                let v2 = stack.Pop()
                let ret = calc current v1 v2
                stack.Push ret
                calcRpn (index + 1) ret
             | _ ->
                 stack.Push(Int32.Parse(current))
                 calcRpn (index + 1) returnValue
            
        calcRpn 0 0
      
   
     printfn "Hello from F#1"
