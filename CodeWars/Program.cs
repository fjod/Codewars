using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        private static Dictionary<int, int> steps = new Dictionary<int, int>();
        public static int ClimbStairs(int n)
        {
            if(n<3) return n;
            if (steps.ContainsKey(n)) return steps[n];
            
            var step1= ClimbStairs(n - 1);
            var step2= ClimbStairs(n - 2);
            steps[n] = step1 + step2;
            return step1 + step2;
        }

        static void Main(string[] args)
        {
            var q = ClimbStairs(5  );
            Console.WriteLine("Length of lis is ");
        }
    }
}