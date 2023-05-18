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
            public int[][] RotateGrid(int[][] grid, int k)
            {
                int bottom = grid.Length - 1, right = grid[0].Length - 1; //Bottom right coordinates
                int top = 0, left = 0; //Top left coordinates
                while (bottom > top && right > left)
                {
                    int total_layer_elements = 2 * (bottom - top) + 2 * (right - left); //Total elements in current layer
                    int num_of_rotations = k % total_layer_elements; //Number of rotations to be performed for the current layer.
                    while (num_of_rotations-- > 0)
                    {
                        int temp = grid[top][left];
                        for (int j = left; j < right; j++)
                        {
                            //Left to Right in current Top row
                            grid[top][j] = grid[top][j + 1];
                        }

                        for (int i = top; i < bottom; i++)
                        {
                            //Top to Bottom in current Right column
                            grid[i][right] = grid[i + 1][right];
                        }

                        for (int j = right; j > left; j--)
                        {
                            //Right to Left in current Bottom row
                            grid[bottom][j] = grid[bottom][j - 1];
                        }

                        for (int i = bottom; i > top; i--)
                        {
                            //Bottom top Top in current left column
                            grid[i][left] = grid[i - 1][left];
                        }

                        grid[top + 1][left] = temp;
                    }

                    top++;
                    left++;
                    bottom--;
                    right--;
                }

                return grid;
            }


            static void Main(string[] args)
            {
                // var q = MaxProfit(new []{7,1,5,3,6,4});
                var q = CountVowelStrings(32);
            }
        }
    }
}