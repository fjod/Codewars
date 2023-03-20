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
        public bool MergeTriplets(int[][] triplets, int[] target)
        {
            // Remove all triplets which contains such item that merging them will cause bad result
            var work = triplets.Where(t => t[0] <= target[0] && t[1] <= target[1] && t[2] <= target[2]).ToList();
            for (int i = 0; i < target.Length; i++)
            {
                var tripletTarget = target[i];
              
                var anyTripletContainTarget = work.Any(t => t[i] == tripletTarget);
                if (!anyTripletContainTarget) return false;
            }

            return true;
        }
        

        
        
        static void Main(string[] args)
        {
            var q = IsNStraightHand(new[] {1,2,3,6,2,3,4,7,8}, 3);

            Console.ReadKey();
        }
    }
}