using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            return nums
                .GroupBy(g => g)
                .Select(g => (g.Key, g.Count()))
                .OrderByDescending(g => g.Item2)
                .Take(k)
                .Select(z => z.Key)
                .ToArray();
        }


        static void Main(string[] args)
        {
            var test = TopKFrequent(new[] {1,1,1,2,2,3}, 2);
            Console.ReadKey();
        }
    }
}