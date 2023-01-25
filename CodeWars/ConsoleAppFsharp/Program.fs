open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    
    let mutable start: Option<ListNode> = None            
        
    let rec innerMerge(list1 : Option<ListNode>, list2 : Option<ListNode>, ret: Option<ListNode>) =         
         match (list1, list2, ret) with
            | None, None, _ -> start           
            | Some l1, Some l2, None when l1.V < l2.V ->
                start <- Some (ListNode l1.V)
                innerMerge (l1.Next, list2, start)
            | Some l1, Some l2, None when l1.V >= l2.V ->
                start <- Some (ListNode l2.V)
                innerMerge (list1, l2.Next, start)
            | None, Some l2, Some ret ->             
                ret.Next <- Some l2
                start
            | Some l1, None, Some ret ->
                ret.Next <- Some l1
                start
            | Some l1, Some l2, Some ret when l1.V < l2.V ->
                let next = ListNode(l1.V)
                ret.Next <- Some next
                innerMerge (l1.Next, list2, ret.Next)
             | Some l1, Some l2, Some ret when l1.V >= l2.V ->
                let next = ListNode(l2.V)
                ret.Next <- Some next
                innerMerge (list1, l2.Next, ret.Next)     
             | _ -> start   
                
    let mergeLists(list1 : Option<ListNode>, list2 : Option<ListNode>) =
        match (list1, list2) with
            | None, None -> None
            | Some _, None -> list1
            | None, Some _ -> list2
            | Some _, Some _ -> innerMerge(list1, list2, None)
        
    let node4Left = ListNode 4
    let node2Left = ListNode (2, Some node4Left)
    let node1Left = ListNode (1, Some node2Left)
    
    let node4r = ListNode 4
    let node2r = ListNode (3, Some node4r)
    let node1r = ListNode (1, Some node2r)
    
    let test = mergeLists (Some node1Left, Some node1r)
    
    printfn "Hello from F#1"
