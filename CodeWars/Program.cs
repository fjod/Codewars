using System;
using System.Linq;


namespace CodeWars
{
   
    class Program
    {
        public static int ProjectionArea(int[][] grid)
        {
            var bottom = grid.Sum(m=>m.Count(i => i >0));
            var leftSide = 0;
            var rightSide = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                leftSide+=grid.Max(g => g[i]);
                rightSide += grid[i].Max();
            }
            return bottom + leftSide + rightSide;
        }
        static void Main(string[] args)
        {
            var a1 = new[] {1, 0};
            var a2 = new[] {0, 2};
            var ret = ProjectionArea(new[] {a1, a2});

            Console.ReadKey();
        }
    }
}
//883. Projection Area of 3D Shapes
