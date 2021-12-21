using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
   
    class Program
    {
        
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> ret = new List<int>();

            int i = 0;
            nums = nums.OrderBy(i1 => i1).ToArray();
            foreach (var v in  Enumerable.Range(1, nums.Length))
            {
                bool found = false;
                while (true)
                {
                    if (i < nums.Length)
                        if (nums[i] == v)
                        {
                            found = true;
                            i++;
                        }
                        else break;
                    else break;
                }
                if (!found) ret.Add(v);
            }

            return ret;
        }

      
        static void Main(string[] args)
        {
            var a = new[] {4,3,2,7,8,2,3,1}; 
            var b = FindDisappearedNumbers(a);
            
            Console.ReadKey();
        }
    }
}