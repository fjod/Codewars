using System;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool CheckIfExist(int[] arr)
        {
            if (arr.Length < 2) return false;
            
            bool foundEntry(int search, int shift)
            {
                for (int i = shift; i < arr.Length; i++)
                {
                    if (arr[i] == search) return true;
                }

                return false;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    var currrentDouble2 = arr[i] * 2;
                    var currentDivide2 = arr[i] / 2;
                    var foundDouble2 = foundEntry(currrentDouble2,i+1);
                    var foundDiv2 = foundEntry(currentDivide2,i+1);
                    if (foundDiv2 || foundDouble2) return true;
                }
                else
                {
                    var currrentDouble2 = arr[i] * 2;
                    var foundDouble2 = foundEntry(currrentDouble2,i+1);
                    if (foundDouble2) return true;
                }
               
            }

            return false;
        }

        static void Main(string[] args)
        {
            var test = new[] {10, 2, 5, 3};
            var ret = CheckIfExist(test); //[0,1,2,3,4,_,_,_,_,_] 5
            test = new[] {3,1,7,11};
            ret = CheckIfExist(test); //[0,1,2,3,4,_,_,_,_,_] 5
            Console.ReadKey();
        }
    }
}