using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace CodeWars
{
    class Program
    {

        public static int[] DailyTemperatures(int[] temperatures)
        {
            Stack<(int temp, int index)> stack = new Stack<(int temp, int index)>(temperatures.Length);
            int[] ret = new int[temperatures.Length];
            int counter = 0;
            foreach (var temperature in temperatures)
            {
                if (stack.Count == 0)
                {
                    stack.Push((temperature, 0));
                    counter++;
                }
                else
                {
                    var prev = stack.Peek();
                    do
                    {
                        prev = stack.Peek();
                        if (prev.temp < temperature)
                        {
                            stack.Pop();
                            var targetLength = counter - prev.index;
                            ret[prev.index] = targetLength;
                        }
                        else break;
                        if (stack.Count == 0) break;
                        
                    } while (prev.temp < temperature);
                   
                    stack.Push((temperature, counter));
                    counter++;
                }
            }

            return ret;
        }


        static void Main(string[] args)
        {
                                                // [1,1,4,2,1,1,0,0]
            var q = DailyTemperatures(new []{73,74,75,71,69,72,76,73});
            Console.ReadKey();
        }
    }
}