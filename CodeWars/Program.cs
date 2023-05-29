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
            public int FindLHS(int[] nums)
            {
                int ret = 0;
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dictionary.ContainsKey(nums[i])) dictionary[nums[i]]++;
                    else
                    {
                        dictionary.Add(nums[i], 1);
                    }
                }

                foreach (var (key, value) in dictionary)
                {
                    if (dictionary.ContainsKey(key + 1))
                        ret = Math.Max(ret, value + dictionary[key + 1]);
                }

                return ret;
            }

            static void Main(string[] args)
            {
                var arr = IsAlienSorted(new []{"apple", "app"}, "abcdefghijklmnopqrstuvwxyz");
            }
        }
    }
}