using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Schema;

namespace CodeWars
{
    class Program
    {
        public class Solution
        {
            public static IList<int> LuckyNumbers (int[][] matrix)
            {
                List<int> ret = new List<int>();
          
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    int max = 0;
                    int col = 0;
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if (matrix[j][i] > max)
                        {
                            max = matrix[j][i];
                            col = j;
                        }
                    }

                    if (matrix[col].Min() == max)
                    {
                        ret.Add(max);
                    }
                }

                return ret;
            }

            static void Main(string[] args)
            {
                var arr = LuckyNumbers(new[] {new []{1,10,4,2}, new []{9,3,8,7}, new []{15,16,17,12}});
            }
        }
    }
}