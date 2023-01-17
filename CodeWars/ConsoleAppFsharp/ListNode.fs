module ListNodeDef

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