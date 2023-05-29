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
            public static int DistanceBetweenBusStops(int[] distance, int start, int destination)
            {

                var forward = 0;
                var backward = 0;

                if (start < destination)
                {
                    for (int i = start; i < destination; i++)
                    {
                        forward += distance[i];
                    }

                    for (int i = destination; i < distance.Length; i++)
                    {
                        backward += distance[i];
                    }
                    for (int i = 0; i < start; i++)
                    {
                        backward += distance[i];
                    }
                }
                else
                {
                    for (int i = destination; i < start; i++)
                    {
                        backward += distance[i];
                    }

                    for (int i = start; i < distance.Length; i++)
                    {
                        forward += distance[i];
                    }
                    for (int i = 0; i < destination; i++)
                    {
                        forward += distance[i];
                    }
                }

                return Math.Min(forward, backward);
            }

            static void Main(string[] args)
            {
                var arr = DistanceBetweenBusStops(new []{7,10,1,12,11,14,5,0}, 7 , 2);
            }
        }
    }
}