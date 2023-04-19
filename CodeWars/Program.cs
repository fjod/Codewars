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
        public static void Rotate(int[][] matrix) {
        
            //write function to transpose matrix
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix[i].Length; j++)
                {
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
                }
            }
            
            //write function to reverse matrix
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length / 2; j++)
                {
                    (matrix[i][j], matrix[i][matrix[i].Length - 1 - j]) = (matrix[i][matrix[i].Length - 1 - j], matrix[i][j]);
                }

            }
        }

        static void Main(string[] args)
        {
            Rotate(new []{new []{1,2,3}, new []{4,5,6}, new []{7,8,9}});
        }
    }
}