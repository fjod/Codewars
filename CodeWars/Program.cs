using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWars
{
  

    class Program
    {
        
        static public int[] SortArrayByParity(int[] A)
        {
            return (A.Where(i => i % 2 == 0)).Concat((A.Where(i => i % 2 != 0))).ToArray();
        }
        static void Main(string[] args)
        {
            var e = SortArrayByParity(new[] {3, 1, 2, 4});
            Console.ReadKey();
        }
    }
}

