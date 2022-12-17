namespace CodeWars
{
    class Program
    {
        public static bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;
            var adjList = new System.Collections.Generic.List<System.Collections.Generic.List<int>>(n);
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new System.Collections.Generic.List<int>());
            }

            for (int i = 0; i < edges.Length; i++)
            {
                var src = edges[i][0];
                var dest = edges[i][1];
                adjList[src].Add(dest);
                adjList[dest].Add(src);
            }

            System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();
            stack.Push(source);

            System.Collections.Generic.List<int> processed = new System.Collections.Generic.List<int>();

            // start from source element
            var currentElement = stack.Pop();
            var fromAdjList = adjList[currentElement];
            fromAdjList.ForEach(e => stack.Push(e));
            
            processed.Add(currentElement);
            while (true)
            {
                if (stack.Count == 0) return false;

                currentElement = stack.Pop();
                if (currentElement == destination)
                {
                    return true;
                }

                if (!processed.Contains(currentElement))
                {
                    fromAdjList = adjList[currentElement];
                    fromAdjList.ForEach(e => stack.Push(e));
                    processed.Add(currentElement);
                }
            }
        }

        static void Main(string[] args)
        {
            int[][] input = new[]
            {
                new int[] {0, 7},
                new int[] {0, 8},
                new int[] {6, 1},
                new int[] {2, 0},
                new int[] {0, 4},
                new int[] {5, 8},
                new int[] {4, 7},
                new int[] {1, 3},
                new int[] {3, 5},
                new int[] {6, 5}
            };

            var q = ValidPath(10, input, 7, 5);
        }
    }
}