using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        static readonly IList<IList<int>> result = new List<IList<int>>();

        private static void backTrack(int index, int total, int[] candidates, int target, List<int> path)
        {
            if (total == target)
            {
                result.Add(path.ToList());
                return;
            }

            if (total > target || index >= candidates.Length) return;
            path.Add(candidates[index]);
            backTrack(index, total + candidates[index], candidates, target, path);
            path.Remove(path.Last());
            backTrack(index+1, total, candidates, target, path);
        }
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            backTrack(0, 0, candidates, target, new List<int>());
            return result;
        }
            
        


        static void Main(string[] args)
        {
            var q = CombinationSum(new[] {2,3,6,7}, 7);
            Console.ReadKey();
        }
    }
}