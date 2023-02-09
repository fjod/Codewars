using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeWars
{
    class Program
    {
        
        public static bool CheckInclusion(string s1, string s2)
        {
            var s1Length = s1.Length;
            var s2Length = s2.Length;

            if (s1Length > s2Length) return false;

            var s1Count = new int[26]; //alphabet and count of letters
            foreach (var ch in s1)
                s1Count[ch - 'a']++;

            var s2Count = new int[26];
            for (int i = 0; i < s2Length; i++)
            {
                s2Count[s2[i] - 'a']++; //add letter to another alphabet
                if (i >= s1Length)
                    s2Count[s2[i - s1Length] - 'a']--;  //if current char of s2 is on position away from s1 len, then decrease it's count in s2 alphabet

                if (s2Count.SequenceEqual(s1Count))
                    return true;
            }

            return false;
        }
    
        static void Main(string[] args)
        {
            CheckInclusion("prospe", "properties");
            Console.ReadKey();
        }
    }
}