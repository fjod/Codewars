using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
   
    class Program
    {
        public static int HeightChecker(int[] heights)
        {

            var sorted = heights.OrderBy(s=>s).ToArray();
            var counter = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (sorted[i] != heights[i]) counter++;
            }

            return counter;
        }

      
        static void Main(string[] args)
        {
            var a = new[] {5,1,2,3,4}; 
            var b = HeightChecker(a);
            
            Console.ReadKey();
        }
    }
}