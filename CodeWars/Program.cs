using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool IsNStraightHand(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0) return false;

            var ordered = hand.ToList().OrderBy(h => h).ToList();
            return work(ordered, groupSize);

        }

        static bool work(List<int> nums, int groupSize)
        {
            if (nums.Count < groupSize) return false;

            int prev = nums.Min();
            nums.Remove(prev);
            for (int i = 1; i < groupSize; i++)
            {
                var current = nums.FirstOrDefault(c => c == (prev+1));
                if (current== 0) return false;
                var toRemove = current;
                nums.Remove(toRemove);
                prev = toRemove;
            }

            if (nums.Count == 0) return true;
            return work(nums, groupSize);
        }
        

        
        
        static void Main(string[] args)
        {
            var q = IsNStraightHand(new[] {1,2,3,6,2,3,4,7,8}, 3);

            Console.ReadKey();
        }
    }
}