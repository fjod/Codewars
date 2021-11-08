using System;

namespace CodeWars
{
    class Program
    {
        static int maxNumber(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }
            int counter = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    counter++;
                    if (counter > max)
                        max = counter;
                }
                else
                {
                    counter = 0;
                }
            }

            return max;
        }
        static void Main(string[] args)
        {
            var i = maxNumber(new[] {1,0,1,1,0,1});
            Console.ReadKey();
        }
    }
}

