using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace CodeWars
{
    class Program
    {
       
        public static int ArrangeCoins(int n)
        {
            int stair = 1;
            while (true)
            {
                n -= stair;
                if (n == 0) return stair;
                if (n < 0) return stair - 1;
                stair += 1;
            }
        }
        static void Main(string[] args)
        {
            var q = ArrangeCoins(5);
            Console.ReadKey();
        }
    }
}