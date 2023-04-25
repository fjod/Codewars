open System
open System.Collections.Generic
open ConsoleAppFsharp
open ListNodeDef
open TreeNodeDef
open ConsoleAppFsharp.Node

module ConsoleAppFsharp =

        
     let Combine(n:int)(k:int) =
         let rec generate (out:List<IList<int>>) (current:IList<int>) (start:int) =
             if (current.Count = k) then
                 let temp = List<int>()
                 temp.AddRange(current)
                 out.Add(temp)
                 ()
             else
                 for i = start to n do
                     current.Add(i)
                     generate out current (i+1)
                     current.RemoveAt(current.Count - 1)
                     ()
             
         
         let output = List<IList<int>>()
         let current = List<int>()
         generate output current 1
         output
     
         
         
     let test = Combine 4 2
     printfn "Hello from F#1"
