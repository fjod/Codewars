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
        public static int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            var set = new HashSet<int>(nums.Length);
            foreach (var num in nums)
            {
                set.Add(num);
            }

            var visited = new HashSet<int>();
            var max = 1;
            foreach (var num in nums)
            {
                if (visited.Contains(num)) continue;
                visited.Add(num);
                var currentMax = 1;
                var next = num + 1;
                while (set.Contains(next))
                {
                    visited.Add(next);
                    currentMax++;
                    next++;
                }

                var prev = num - 1;
                while (set.Contains(prev))
                {
                    visited.Add(prev);
                    currentMax++;
                    prev--;
                }

                if (currentMax > max) max = currentMax;
            }

            return max;
        }


        static void Main(string[] args)
        {
            var test = LongestConsecutive(new[] {100, 4, 200, 1, 3, 2});
            Console.ReadKey();
        }
    }
}