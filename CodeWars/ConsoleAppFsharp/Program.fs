open System
open System.Collections.Generic
open ConsoleAppFsharp
open ListNodeDef
open TreeNodeDef
open ConsoleAppFsharp.Node

module ConsoleAppFsharp =

     let maxSub (arr:int[]) =
         let rec calcSum (arr:int[]) (index:int) (max:int) (sum:int) =
             if (index = arr.Length) then max
             else
                 let curSum = sum + arr[index]
                 let curSum = Math.Max(curSum, 0)
                 let maxSub = Math.Max(curSum, max)
                 calcSum arr (index+1) maxSub curSum
         calcSum arr 0 arr[0] 0
     
     let Clone(n:Node) =
         let dict = new Dictionary<Node,Node>()
         let rec cloneInner (z:Node) =
             if (dict.ContainsKey(z)) then dict[z]
             else
                 let current = Node(z.V)
                 dict.Add(z, current)
                 for i in z.Neighbours do
                      let clonedChild = cloneInner i
                      current.Neighbours.Add(clonedChild)              
                 dict[z] 
              
         dict[n]
     
     let test = maxSub [|-2;1;-3;4;-1;2;1;-5;4|]
     printfn "Hello from F#1"
