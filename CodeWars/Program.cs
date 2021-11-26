using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 1)
                return 1;
            if (nums.Length == 0)
                return 0;
            
            int current = 1;
            int duplicate = 1;
            for (int i = 0; i < nums.Length-1; i++)
            {
                if (nums[i] == nums[i+1])
                {
                    duplicate = i+1;
                }
                else
                {
                    nums[current] = nums[duplicate+1];
                    current++;
                }
            }

            return current;
        }

        static void Main(string[] args)
        {
            //var test = new[] {3, 2, 2, 3};
           // var ret = RemoveElement(test, 3);
            
           var test = new[] {0,0,1,1,1,2,2,3,3,4};
           var  ret = RemoveDuplicates(test); //[0,1,2,3,4,_,_,_,_,_] 5
           test = new[] {1,2};
            ret = RemoveDuplicates(test); //[0,1,2,3,4,_,_,_,_,_] 5
           Console.ReadKey();
        }
    }
}

