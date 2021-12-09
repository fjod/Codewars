using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static void MoveZeroes(int[] nums) {
        
            if (nums.Length <= 1) return;

            int retIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[retIndex] = nums[i];
                    retIndex++;
                }
            }

            for (int i = retIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }

        static void Main(string[] args)
        {
            var a = new[] {0,1,0,3,12};
            MoveZeroes(a);
            
            Console.ReadKey();
        }
    }
}