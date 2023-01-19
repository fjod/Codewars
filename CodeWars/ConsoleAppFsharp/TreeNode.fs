module TreeNodeDef
    
    type TreeNode(v : int, left : Option<TreeNode>, right : Option<TreeNode>) =

         member this.V = v
         member this.Left = left
         member this.Right = right
         new(v: int) = TreeNode(v, None, None)
         new(v: int, l : TreeNode, r:TreeNode) = TreeNode(v, Some l, Some r)
         override this.ToString() =
            match (v, left, right) with
            | _, Some _, Some _ -> $"{v} {left.Value} {right.Value}"
            | _, Some _, None -> $"{v}, left {left.Value}"
            | _, None, Some _ -> $"{v}, right {right.Value}"
            | _ -> $"{v}"
