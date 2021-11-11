using System;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static void DuplicateZeros(int[] arr) {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    var nextIndex = i + 1;
                    if (nextIndex == arr.Length) break;
                    var leftLength = arr.Length - i-2;
                    Array.Copy(arr,nextIndex,arr,nextIndex+1,leftLength);
                    arr[nextIndex] = 0;
                    i++;
                }   
            }
        }
        static void Main(string[] args)
        {
            var i = new[] {1, 0, 2, 3, 0, 4, 5, 0};
            DuplicateZeros(i);
            Console.ReadKey();
        }
    }
}

