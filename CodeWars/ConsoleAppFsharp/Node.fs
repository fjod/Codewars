module ConsoleAppFsharp.Node

    type Node(v:int, neighbours: System.Collections.Generic.List<Node>) =
        member this.V = v
        member this.Neighbours = neighbours        
        
        new(v: int) = Node(v, new System.Collections.Generic.List<Node>())    

