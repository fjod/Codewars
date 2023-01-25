using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        static int lis(int[] arr)
        {
            int n = arr.Length;
            int[] lisValues = new int[n];
            int i, j, max = 0;

            /* Initialize LIS values for all indexes */
            for (i = 0; i < n; i++) lisValues[i] = 1;

            /* Compute optimized LIS values in bottom up manner             */
            for (i = 1; i < n; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j] && lisValues[i] < lisValues[j] + 1)
                        lisValues[i] = lisValues[j] + 1;

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lisValues[i])  max = lisValues[i];

            return max;
        }

        static void Main(string[] args)
        {
            int[] arr = { 10, 22, 9, 33, 21, 50, 41, 60 };
            int n = lis(arr);
            Console.WriteLine("Length of lis is ");
        }
    }
}