using System;
using System.Collections.Generic;


namespace CodeWars
{
    class Program
    
    {
        
        public static int[] TwoSum(int[] nums, int target) {
            Dictionary<int,int> map = new Dictionary<int,int>();
            for (int i = 0; i < nums.Length; i++) {
                int complement = target - nums[i];
                if (map.ContainsKey(complement)) {
                    return new int[] { map[complement], i };
                }
                map.Add(nums[i],i);
            }

            throw new Exception();
        }
        
        static void Main(string[] args)
        {
            var q = TwoSum(new[] {2, 7, 11, 15}, 9);
            Console.ReadKey();
        }
    }
}