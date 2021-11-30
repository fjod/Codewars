using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        public static bool ValidMountainArray(int[] arr)
        {
            if (arr.Length <= 2)
            {
                return false;
            }
            if (arr.Length == 3)
            {
                return arr[0] < arr[1] && arr[1] > arr[2];
            }
            int start = 0;
            int stop = arr.Length-1;
            int? startEnd = null;
            int? stopEnd = null;
            while (true)
            {
                if (startEnd != null && stopEnd != null)
                {
                    return startEnd == stopEnd;
                }
                int startNext = start + 1;
                int stopPrev = stop - 1;
                if (startNext == arr.Length) startEnd = arr.Length - 1;
                if (stopPrev < 0) stopEnd = 0;
                if (startEnd == null) if (arr[startNext] <= arr[start]) startEnd = start;
                if (stopEnd == null) if (arr[stopPrev] <= arr[stop]) stopEnd = stop;
                start++;
                stop--;
            }
        }

        static void Main(string[] args)
        {
            var test = ValidMountainArray(new[] {0,1,2,1,2});
            Console.ReadKey();
        }
    }
}