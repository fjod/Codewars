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
            public static char SlowestKey(int[] releaseTimes, string keysPressed)
            {
                List<(char, int)> durations = new List<(char, int)>();
                int current = 0;
                int longest = 0;
                foreach (var c in keysPressed)
                {
                    var dur = releaseTimes[current];
                    if (current != 0) dur = releaseTimes[current] - releaseTimes[current - 1];
                    if (current >= longest)
                    {
                        durations.Add((c, dur));
                    }
                    
                    current++;
                }

                var maxDur = durations.Max(d => d.Item2);
                var durationsWithMaxTime = durations.Where(d => d.Item2 == maxDur).OrderByDescending(d => d.Item1).First();
                return durationsWithMaxTime.Item1;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = SlowestKey(new []{9,29,49,50}, "cbcd");
            }
        }
    }
}