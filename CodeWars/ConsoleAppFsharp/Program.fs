open ListNodeDef

module ConsoleAppFsharp =
    
    let reverseList(node:Option<ListNode>) : Option<ListNode> =
        match node with
        | None -> None
        | Some listNode ->
            match listNode.Next with
            | None -> Some listNode
            | _ ->
                let mutable prev = None
                let mutable current = node
                while current.IsSome do
                    let nextForCurrent = current.Value.Next
                    current.Value.Next <- prev
                    prev <- current
                    current <- nextForCurrent
                prev
        
    let rec reverseListRec (current:Option<ListNode>) : Option<ListNode> =
        match current.Value.Next with
        | None -> current
        | Some next ->          
                let last = reverseListRec (Some next)
                current.Value.Next.Value.Next <- current
                current.Value.Next <- None
                last

   
    let t3 = ListNode(3)
    let t2 = ListNode(2, Some t3)
    let t1 = ListNode(1, Some t2)

    let t = reverseListRec (Some t1)
    printfn "Hello from F#"
