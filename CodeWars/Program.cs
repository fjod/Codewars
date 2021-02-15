using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWars
{
  

    class Program
    {
        
        public static int SmallestRangeI(int[] A, int K)
        {
            if (A.Length <= 1) return 0;
            var sorted = A.ToList().OrderBy(i => i);
            return Math.Max(sorted.Max() - K*2 - sorted.Min(),0);
        }
        static void Main(string[] args)
        {
            var q = SmallestRangeI(new[] {1, 3,6}, 3);
            Console.ReadKey();
        }
    }
}

//I am too stupid to understand math solution, so here is mine 
