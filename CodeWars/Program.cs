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
        public static IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> ret = new List<IList<int>>(numRows);
            for (int i = 0; i < numRows; i++)
            {
                ret.Add(new List<int>());
            }

            generate(numRows, 0, ret);
            return ret;
        }

        private static void generate(int numRows, int current, List<IList<int>> ret)
        {
            if (current == numRows) return;
            if (current == 0)
            {
                ret[current].Add(1);
            }
            else
            if (current == 1)
            {
                ret[current].Add(1);
                ret[current].Add(1);
            }
            else
            {
                ret[current].Add(1);
                for (int i = 1; i < current; i++)
                {
                    ret[current].Add(ret[current - 1][i - 1] + ret[current - 1][i]);
                }
                ret[current].Add(1);
            }
            
            generate(numRows, current + 1, ret);
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = Generate(5);
         
        }
    }
}