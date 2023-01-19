open TreeNodeDef

module ConsoleAppFsharp =

    let rec SearchBst (node: Option<TreeNode>, target: int) : Option<TreeNode> =
        match node with
        | None -> None
        | Some treeNode ->
            if (treeNode.V = target) then
                node
            else
                match (treeNode.V, treeNode.Left, treeNode.Right) with
                | v, Some _, _ when v > target -> SearchBst(treeNode.Left, target)
                | v, _, Some _ when v < target -> SearchBst(treeNode.Right, target)
                | _ -> None



    let t1 = TreeNode(1)
    let t3 = TreeNode(3)
    let t2 = TreeNode(2, t1, t3)
    let t7 = TreeNode(7)
    let t4 = TreeNode(4, t2, t7)

    let test = SearchBst(Some t4, 2)

    printfn "Hello from F#"
