using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static System.Collections.Generic.IList<System.Collections.Generic.IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int source = 0;
            int target = graph.Length - 1;
            System.Collections.Generic.List<System.Collections.Generic.List<int>> ret =
                new System.Collections.Generic.List<System.Collections.Generic.List<int>>();
            System.Collections.Generic.Stack<System.Collections.Generic.List<int>> stack =
                new System.Collections.Generic.Stack<System.Collections.Generic.List<int>>();

            foreach (var i in graph[source])
            {
                stack.Push(new System.Collections.Generic.List<int> {source, i});
            }

            while (stack.Count > 0)
            {
                var currentPaths = stack.Pop();
                var lastVertex = currentPaths.Last();
                if (lastVertex == target)
                {
                    ret.Add(currentPaths);
                    continue;
                }


                var lastVertexPaths = graph[lastVertex];
                for (int i = 0; i < lastVertexPaths.Length; i++)
                {
                    var updated = new System.Collections.Generic.List<int>();
                    updated.AddRange(currentPaths);
                    updated.Add(lastVertexPaths[i]);
                    stack.Push(updated);
                }
            }

            System.Collections.Generic.List<System.Collections.Generic.IList<int>> rret =
                new System.Collections.Generic.List<System.Collections.Generic.IList<int>>();
            rret.AddRange(ret);
            return rret;
        }

        static void Main(string[] args)
        {
            //                      0 -> (1,2)    1 -> (3)   1 -> (3)     (3) no connections
            // int[][] graph = new[] {new[] {1, 2}, new[] {3}, new[] {3}, System.Array.Empty<int>() };
            // var q = AllPathsSourceTarget(graph);

            int[][] graph = new[] {new[] {4, 3, 1}, new[] {3, 2, 4}, new[] {3}, new[] {4}, System.Array.Empty<int>()};
            var q = AllPathsSourceTarget(graph);
        }
    }
}