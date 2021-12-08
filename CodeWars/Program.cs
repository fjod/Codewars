using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 1) return 1;
            if (nums.Length == 0) return 0;
            if (nums.Length == 2 && nums[0] != nums[1]) return 2;
            int duplicate = 0;
            int start = 1;
            for (int i = 0; i < nums.Length-1; i++)
            {
                var next = nums[i + 1];
                if (nums[i] == next)
                {
                    duplicate++;
                }
                else
                {
                    nums[start] = nums[i + 1];
                    start++;
                }
            }

            return duplicate;
        }

        static void Main(string[] args)
        {
            var a = new[] {1, 1, 2};
            var test = RemoveDuplicates(a);
            
            Console.ReadKey();
        }
    }
}