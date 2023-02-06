open System
open System.Collections.Generic
open ListNodeDef
open TreeNodeDef

module ConsoleAppFsharp =

    let RemoveNthFromEnd (head: Option<ListNode>) (n: int) =

        match (head, n) with
        | None, n when n <= 0 -> None
        | _ ->
            let fakehead = ListNode -1
            fakehead.Next <- head
            let mutable n1 = Some(ListNode -1)
            let mutable n2 = Some (ListNode -2)

            for i in 0..n do
                n1 <- n1.Value.Next

            if n1.IsNone then
                None
            else
                while (n1.Value.Next <> None) do
                    n1 <- n1.Value.Next
                    n2 <- n2.Value.Next
                n2.Value.Next <- n2.Value.Next.Value.Next
                Some fakehead.Next






    printfn "Hello from F#1"
