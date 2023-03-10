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
        
         
     let maxDepth(root:TreeNode) =
         let rec depth(n:TreeNode option) (d:int) =
             if n.IsNone then d
             else
                let left = depth n.Value.Left d  + 1
                let right = depth n.Value.Right d + 1
                Math.Max(left,right)
         let left = depth root.Left 1
         let right = depth root.Right 1
         Math.Max(left,right)
     
     // 💘 So clean
     let rec compare(p:TreeNode option) (q:TreeNode option) =
         match p,q with
         | None, None -> true       
         | Some v1, Some v2 when v1.V <> v2.V -> false
         | Some v1, Some v2 -> compare v1.Left v2.Left && compare v1.Left v2.Right
         | _ -> false
         
     
     let node = TreeNode(4, TreeNode(1,TreeNode(1),TreeNode(3)),TreeNode(7,TreeNode(6), TreeNode(9)))
     let test = invertTree node
     printfn "Hello from F#1"
