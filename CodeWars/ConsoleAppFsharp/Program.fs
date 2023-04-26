open System
open System.Collections.Generic
open ConsoleAppFsharp
open ListNodeDef
open TreeNodeDef
open ConsoleAppFsharp.Node

module ConsoleAppFsharp =

        
     let isValidBst (root:TreeNode option) :bool =
         let rec isValid (node:TreeNode option) (min:Int64) (max:Int64) =
             if (root.IsNone) then true
             else
                 if (int64 root.Value.V <= min || int64 root.Value.V >= max) then false
                 else
                     let left = isValid root.Value.Left min root.Value.V
                     let right = isValid root.Value.Right root.Value.V max
                     left && right
             
         
         isValid root Int64.MinValue Int64.MaxValue
         
         
     let test = Combine 4 2
     printfn "Hello from F#1"
