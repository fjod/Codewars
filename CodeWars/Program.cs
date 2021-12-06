using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static int[] ReplaceElements(int[] arr)
        {
            var max = -1;
            for (var i = arr.Length - 1; i >= 0; i--) {
                var tmp = arr[i];
                arr[i] = max;
                if (tmp > max) {
                    max = tmp;
                }
            }

            return arr;
        }

        static void Main(string[] args)
        {
            var test = ReplaceElements(new[] {17,18,5,4,6,1});
            
            Console.ReadKey();
        }
    }
}