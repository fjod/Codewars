using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
   
    class Program
    {
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int currentOneCount = 0;
            int consecutiveOneCount = 0;
            int maxOneCount = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == 1) {
                    currentOneCount++;
                    consecutiveOneCount++;
                } else {
                    currentOneCount = consecutiveOneCount;
                    currentOneCount++;
                    consecutiveOneCount = 0;
                }
                if (currentOneCount > maxOneCount)
                    maxOneCount = currentOneCount;
            }
            return maxOneCount;
        }

      
        static void Main(string[] args)
        {
            var a = new[] {0,1,0,0,1}; 
            var b = FindMaxConsecutiveOnes(a);
            
            Console.ReadKey();
        }
    }
}