using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int RemoveElement(int[] nums, int val)
        {
            int counter = 0;
            int dups = 0;
            for (int i = 0; i < nums.Length- dups; i++)
            {
                if (nums[i] == val)
                {
                    for (int k = i; k < nums.Length-1; k++) //сдвинуть остаток влево
                    {
                        nums[k] = nums[k + 1];
                    }

                    i--;
                    dups++;
                }
                counter++;
            }

            return counter-dups;
        }

        static void Main(string[] args)
        {
            //var test = new[] {3, 2, 2, 3};
           // var ret = RemoveElement(test, 3);
            
           var test = new[] {0,1,2,2,3,0,4,2};
           var  ret = RemoveElement(test, 2); //[0,1,4,0,3,_,_,_] 5
            Console.ReadKey();
        }
    }
}

