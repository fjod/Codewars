using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    class Program
    {
        public static IList<int> GetRow(int rowIndex)
        {
            
            var ret = Init(rowIndex+1);
            if (rowIndex <= 1)
            {
                return ret[rowIndex];
            }

            CalculateTriangles(ret, rowIndex+1);
            
            return ret[rowIndex];
        }

        private static void CalculateTriangles(List<List<int>> ret, int rowIndex)
        {
            for (int i = 2; i < rowIndex; i++)
            {
                var current = ret[i];
                var prev = ret[i - 1];
                current[0] = 1;
                current[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    current[j] = prev[j - 1] + prev[j];
                }
            }
        }

        private static List<List<int>> Init(int rowIndex)
        {
            List<List<int>> ret = new List<List<int>>(rowIndex);
            for (int i = 0; i < rowIndex; i++)
            {
                ret.Add(new List<int>(i+1));
                for (int j = 0; j < i + 1; j++)
                {
                    ret[i].Add(0);
                }
                
            }

            ret[0][0] = 1;
            if (ret.Count > 1)
            {
                ret[1][0] = 1;
                ret[1][1] = 1;
            }

            return ret;
        }

        static void Main(string[] args)
        {
            var q = GetRow(0);
            Console.ReadKey();
        }
    }
}