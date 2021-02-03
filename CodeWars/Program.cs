using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CodeWars
{
    class Program
    
    {
        
        public static string LongestCommonPrefix(string[] strs)
        {
            if (!strs.Any()) return "";
            StringBuilder[] arr = new StringBuilder[strs.Length];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = new StringBuilder();
            }
            int counter = 0;
            int maxLen = strs.Max(l => l.Length);
            bool prevStringsEqual = false;
            do
            {
                prevStringsEqual = false;
                var firstString = arr.First().ToString();
                if (arr.First().Length > 0)
                {
                    prevStringsEqual = arr.All(sb => sb.ToString() == firstString);
                    if (prevStringsEqual == false) return "";
                }
                for (int i = 0; i < strs.Length; i++)
                {
                    if ( counter<strs[i].Length )
                        arr[i].Append(strs[i][counter]);
                }
                var nextString = arr.First().ToString();
                
                    if (arr.Any(sb => sb.ToString() != nextString))
                    {
                        if (counter > 0)
                            return firstString;
                    }
                    counter++;

            } while (counter < maxLen+1);
            if (prevStringsEqual) return arr.First().ToString();
            return "";
        }
        
        static void Main(string[] args)
        {
            string[] strs = { "a"};
            Console.WriteLine(LongestCommonPrefix(strs));
            Console.ReadKey();
        }
    }
}

//I used "vertical scanning" approach, which is pretty good
//The only problem is that I used it like an idiot
//There is no need to save strings in StringBuilders and compare contents
//I can compare chars and in successful case return part of any string from start to current index 