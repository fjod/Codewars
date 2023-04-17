using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {
        //1057 / 1157 testcases passed
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;

            List < List<int>> arr = new List<List<int>>();
            for (int i = 0; i < numRows; i++)
            {
                arr.Add(Enumerable.Repeat(int.MaxValue, 100).ToList());
            }

            int current = 0;
            bool isDown = true;
            int columnShift = 0;
            int rowShift = 1;
            for (int i = 0; i < s.Length; i++)
            {
                if (current < numRows && isDown == true)
                {
                    arr[current][columnShift] = i;
                    current++;
                }
                else if (current >= 1 && isDown == false)
                {
                    current--;
                    arr[current][columnShift+rowShift] = i;
                    rowShift++;
                }


                if (current == numRows && isDown)
                {
                    isDown = false;
                    current--;
                };
                if (current == 1 && !isDown)
                {
                    isDown = true;
                    columnShift+=numRows-1;
                    rowShift = 1;
                    current = 0;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    var current2 = arr[i][j];
                    if (current2 != int.MaxValue)
                    {
                        sb.Append(s[current2]);
                    }
                }
            }

            return sb.ToString();
        }
        
        public string Convert2(string s, int numRows) {
            if(numRows == 1 || numRows >= s.Length)
            {
                return s;
            }
            string[] res = new string[numRows];
            int index = 0;
            int step = 1;
            for(int i = 0; i<s.Length;i++)
            {
                res[index] += s[i];
                if(index == 0)
                {
                    step = 1;
                }
                else if(index == numRows - 1)
                {
                    step = -1;
                }
                index += step;
            }
            return string.Join(string.Empty, res);
        }
    


        static void Main(string[] args)
        {
            var q = Convert("PAYPALISHIRING", 3);
        }
    }
}