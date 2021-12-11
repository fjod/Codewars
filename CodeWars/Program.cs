using System;
using System.Text;

namespace CodeWars
{
   
    class Program
    {
        public static int[] SortArrayByParity(int[] nums)
        {

            if (nums.Length <= 1) return nums;
            int findEvenFromStartIndex(int start)
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0) return i;
                }

                return nums.Length;
            }
            
            int findOddFromEndIndex(int end)
            {
                for (int i = end; i > 0; i--)
                {
                    if (nums[i] % 2 == 0) return i;
                }

                return 0;
            }

            int start = findEvenFromStartIndex(0);
            int end = findOddFromEndIndex(nums.Length - 1);
            while (true)
            {
                if (start >= end) return nums;
                (nums[end], nums[start]) = (nums[start], nums[end]);
                start = findEvenFromStartIndex(start);
                end = findOddFromEndIndex(end);
            }

            
        }

      
        static void Main(string[] args)
        {
            var a = new[] {3,1,2,4}; // [2,4,3,1]
            a = SortArrayByParity(a);
            
            Console.ReadKey();
        }
    }
}