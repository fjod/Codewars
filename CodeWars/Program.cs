using System;
using System.Linq;


namespace CodeWars
{
   
    class Program
    {
        public static int SearchInsert(int[] nums, int target) {

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target) return i;
                if (nums[i] > target)
                {
                    return i + 1;
                }
            }

            if (target > nums[^1]) return nums.Length;
            return 0;
        }
        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }
    }
}
//883. Projection Area of 3D Shapes
