// For more information see https://aka.ms/fsharp-console-apps

open System

printfn "Hello from F#"

type ListNode(v: int, next: Option<ListNode>) =
    let mutable next = next
    member this.V = v

    member this.Next
        with get () = next
        and set (v) = next <- v

    new() = ListNode(0, None)

    new(v: int) = ListNode(v, None)

    override this.ToString() =
        match next with
        | Some _ -> $"{v}"
        | None -> $"{v}, empty"



let mutable counter = 0
let mutable exit = false
let mutable prev: Option<ListNode> = None
let mutable start: Option<ListNode> = None

let swapNodes (left: ListNode, right: ListNode) =
    match prev with
    | None ->
        left.Next <- right.Next
        right.Next <- Some left
        start <- Some right
    | Some p ->
        p.Next <- Some right
        let rightNext = right.Next
        right.Next <- Some left
        left.Next <- rightNext
    ()

let rec Swap (node: Option<ListNode>) =
    if (exit || node.IsNone) then
        ()
    else
        match node with
        | Some v ->
            match (counter, v.Next) with
            | 0, Some next ->
                //swap
                let left = v
                let right = next
                swapNodes (left, right)
                counter <- 1
                prev <- Some left
                Swap node
            | _ -> ()
        | _ -> ()

        match (node.Value.Next) with
        | None ->
            exit <- true
            ()
        | Some v ->
            counter <- counter - 1
            prev <- node
            Swap (Some v)
       

let swapPairs (head: Option<ListNode>) =
    match head with
    | None -> None
    | Some h ->
        match h.Next with
        | None -> head
        | Some _ ->
            Swap head
            start

let t4 = ListNode(4)
let t3 = ListNode(3, Some t4)
let t2 = ListNode(2, Some t3)
let t1 = ListNode(1, Some t2)

let t = swapPairs (Some t1)
printfn "Hello from F#"
