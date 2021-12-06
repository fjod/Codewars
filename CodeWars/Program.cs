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
            if (arr.Length == 1)
            {
                arr[^1] = -1;
                return arr;
            }
            int max(Span<int> span)
            {
                int sum = 0;
                foreach (var value in span)
                    if (value > sum)
                        sum = value;

                return sum;
            }
            for (int i = 0; i < arr.Length-1; i++)
            {
                var nextItems = arr.AsSpan(i + 1);
                arr[i] = max(nextItems);
            }

            arr[^1] = -1;
            return arr;
        }

        static void Main(string[] args)
        {
            var test = ReplaceElements(new[] {17,18,5,4,6,1});
            
            Console.ReadKey();
        }
    }
}