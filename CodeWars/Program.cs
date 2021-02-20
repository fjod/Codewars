using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWars
{
  

    class Program
    {
        
        public static int RemoveDuplicates(int[] nums)
        {
           // Input: nums = [0,0,1,1,1,2,2,3,3,4]
           // Output: 5, nums = [0,1,2,3,4]
            int newCount = nums.Length;
            for (int i = 1; i < newCount; i++)
            {
                if (nums[i] == nums[i-1])
                {
                    //shift array 1 left
                  
                    for (int j = i; j < newCount-1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    newCount--;
                    i--;
                }
            }

            return newCount;
        }
        static void Main(string[] args)
        {

            var q = RemoveDuplicates(new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4});
          
            Console.ReadKey();
        }
    }
}
//26. Remove Duplicates from Sorted Array
