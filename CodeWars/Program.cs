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
        private static List<TimeSpan> _leds = new List<TimeSpan>
        {
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(2),
            TimeSpan.FromMinutes(4),
            TimeSpan.FromMinutes(8),
            TimeSpan.FromMinutes(16),
            TimeSpan.FromMinutes(32),
            TimeSpan.FromHours(1),
            TimeSpan.FromHours(2),
            TimeSpan.FromHours(4),
            TimeSpan.FromHours(8),
        };
        
        public static IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<string> output = new List<string>();
            if (turnedOn>=9) return output;
            helper(turnedOn, 0, output, _leds, new List<TimeSpan>());
            return output;
        }

        private static void helper(int turnedOn, int shift, List<string> output, List<TimeSpan> leds, List<TimeSpan> current)
        {
            if (turnedOn == shift)
            {
                    var totalHours = current.Sum(d => d.Hours);
                    var totalMinutes = current.Sum(d => d.Minutes);
                    if (totalHours < 12 && totalMinutes < 60)
                    {
                        var item = $"{totalHours}:{totalMinutes:00}";
                        if (!output.Contains(item)) output.Add(item);
                    }
                
            }
            else
            {
                for (int i = 0; i < leds.Count; i++)
                {
                    current.Add(leds[i]);
                    
                    var localMinutes = new List<TimeSpan>(leds);
                    localMinutes.RemoveAt(i);

                    helper(turnedOn, shift + 1, output, localMinutes, current);

                    current.Remove(leds[i]);
                }
            }
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = ReadBinaryWatch(2);
         
        }
    }
}