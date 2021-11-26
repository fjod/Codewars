using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool CheckIfExist(int[] arr)
        {
            if (arr.Length < 2) return false;
            //Loop from i = 0 to arr.length, maintaining in a hashTable the array elements from [0, i - 1].
            HashSet<int> hs=new HashSet<int>();
            hs.Add(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    var currentDivide2 = arr[i] / 2;
                    var currrentDouble2 = arr[i] * 2;
                    var foundDiv2 = hs.Contains(currentDivide2);
                    var foundDouble2 =hs.Contains(currrentDouble2);
                    if (foundDiv2 ) return true;
                    if (foundDouble2 ) return true;
                }
                else
                {
                    var currrentDouble2 = arr[i] * 2;
                    var foundDouble2 =hs.Contains(currrentDouble2);
                    if (foundDouble2) return true;
                }
                hs.Add(arr[i]);
            }

            return false;
        }

        static void Main(string[] args)
        {
            var test = new[] {-2,0,10,-19,4,6,-8};
            var ret = CheckIfExist(test); //[0,1,2,3,4,_,_,_,_,_] 5
            test = new[] {3,1,7,11};
            ret = CheckIfExist(test); //[0,1,2,3,4,_,_,_,_,_] 5
            Console.ReadKey();
        }
    }
}