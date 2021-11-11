using System;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static int[] SortedSquares(int[] nums)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;
            int[] ret = new int[nums.Length];
            for (int i = nums.Length-1; i >= 0; i--)
            {
                var leftIsBigger = Math.Abs(nums[leftIndex]) >= Math.Abs(nums[rightIndex]);
                if (leftIsBigger)
                {
                    ret[i] = nums[leftIndex] * nums[leftIndex];
                    leftIndex++;
                }
                else
                {
                    ret[i] = nums[rightIndex] * nums[rightIndex];
                    rightIndex--;
                }
            }

            return ret;
        }
        static void Main(string[] args)
        {
            var i = SortedSquares(new[] {-7,-3,2,3,11});
            Console.ReadKey();
        }
    }
}

