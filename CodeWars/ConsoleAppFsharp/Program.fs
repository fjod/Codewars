open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

 
     
      
     let invertTree (root:TreeNode) =
        let rec invert(n:Option<TreeNode>) : Option<TreeNode> =
            if n.IsNone then None
            else
                let left = invert n.Value.Left
                let right = invert n.Value.Right
                let ret = TreeNode(n.Value.V, right, left)
                Some ret
        invert (Some root)
        
         
     
     let node = TreeNode(4, TreeNode(1,TreeNode(1),TreeNode(3)),TreeNode(7,TreeNode(6), TreeNode(9)))
     let test = invertTree node
     printfn "Hello from F#1"
