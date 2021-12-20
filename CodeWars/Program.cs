using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
   
    class Program
    {
        public static int ThirdMax(int[] nums)
        {
            int? firstMax = null;
            int? secondMax = null;
            int? thirdMax = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (firstMax == null)
                {
                    firstMax = nums[i];
                    continue;
                }

                if (firstMax.Value == nums[i]) continue;
                
                if (secondMax == null)
                {
                    if (nums[i] > firstMax)
                    {
                        secondMax = firstMax;
                        firstMax = nums[i];
                        continue;
                    }
                    if (nums[i] <= firstMax)
                    {
                        secondMax = nums[i];
                        continue;
                    }
                }
                
                if (secondMax.Value == nums[i]) continue;
                
                if (thirdMax == null)
                {
                    if (nums[i] > firstMax)
                    {
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = nums[i];
                        continue;
                    }
                    if (nums[i] > secondMax)
                    {
                        thirdMax = secondMax;
                        secondMax = nums[i];
                        continue;
                    }
                    thirdMax = nums[i];
                    continue;
                }
                if (nums[i] > firstMax)
                {
                    thirdMax = secondMax;
                    secondMax = firstMax;
                    firstMax = nums[i];
                    continue;
                }
                if (nums[i] > secondMax)
                {
                    thirdMax = secondMax;
                    secondMax = nums[i];
                    continue;
                }
                if (nums[i] > thirdMax) thirdMax = nums[i];
            }

            if (thirdMax != null) return thirdMax.Value;
            if (firstMax!= null && secondMax!= null) return Math.Max(firstMax.Value, secondMax.Value);
            return firstMax.Value;
        }

      
        static void Main(string[] args)
        {
            var a = new[] {1,2}; 
            var b = ThirdMax(a);
            
            Console.ReadKey();
        }
    }
}