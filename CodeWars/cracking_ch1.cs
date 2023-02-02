﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars;

public class cracking_ch1
{
    public static bool AreAllCharsUnique(string str1)
    {
        HashSet<char> test = new HashSet<char>();
        for (var i = 0; i < str1.Length; i++)
        {
            if (!test.Contains(str1[i])) test.Add(str1[i]);
            else return false;
        }

        return true;
    }
    
    public static bool OneStringIsMixOfOther(string input, string other)
    {
        Dictionary<char, int> vowels = new Dictionary<char, int>();
        for (int i = 0; i < other.Length; i++)
        {
            var current = other[i];
            var vowel = other.Where(v => v == current).ToList();
            if (!vowels.ContainsKey(current)) vowels.Add(current, vowel.Count);
        }

        for (int i = 0; i < input.Length; i++)
        {
            var current = input[i];
            if (!vowels.ContainsKey(current)) return false;
            var amount = vowels[current];
            amount -= 1;
            if (amount < 0) return false;
            vowels[current] = amount;
        }

        return true;
    }
    
    public static string ConvertSpaces(string input, int l)
    {
        var conv = "%20";
        bool lastCharWasConverted = false;
        string ret = string.Empty;
        if (input[0] == ' ')
        {
            lastCharWasConverted = true;
            ret += conv;
        }
        else
        {
            lastCharWasConverted = false;
            ret += input[0];
        }
        for (int i = 1; i < l; i++)
        {
            if (input[i] == ' ' && lastCharWasConverted)
            {
                continue;
            }
            if (input[i] == ' ' && !lastCharWasConverted)
            {
                lastCharWasConverted = true;
                ret += conv;
            }
            else
            {
                lastCharWasConverted = false;
                ret += input[i];
            }
        }

        return ret;
    }
    
    public static bool IsPalindrome(string s)
    {
        var converted = s.ToLower().Replace(" ", string.Empty).Trim();
        converted = System.Text.RegularExpressions.Regex.Replace(converted, "[^a-zA-Z0-9]+", "", System.Text.RegularExpressions.RegexOptions.Compiled);
        if (converted.Length == 1) return true;
        var p1 = 0;
        var p2 = converted.Length - 1;
        while (p1 <= p2)
        {
            if (converted[p1] != converted[p2]) return false;
            p1++;
            p2--;
        }

        return true;
    }

    public static bool OneModification(string s1, string s2)
    {
        Dictionary<char, int> vowels = new Dictionary<char, int>();
        for (int i = 0; i < s1.Length; i++)
        {
            var current = s1[i];
            var vowel = s1.Where(v => v == current).ToList();
            if (!vowels.ContainsKey(current)) vowels.Add(current, vowel.Count);
        }

        bool oneModUsed = false;
        for (int i = 0; i < s2.Length; i++)
        {
            var current = s2[i];
            if (!vowels.ContainsKey(current) && !oneModUsed)
            {
                oneModUsed = true;
                continue;
            }

            if (!vowels.ContainsKey(current) && oneModUsed)
            {
                return false;
            }

            var amount = vowels[current];
            amount -= 1;
            if (amount < 0 && !oneModUsed)
            {
                vowels[current] = amount;
                continue;
            }

            if (amount < 0 && oneModUsed)
            {
                return false;
            }
        }
            
        return s1.Length - s2.Length <=1;
    }
    
    public static int Compress(char[] chars)
    {
        string ret = String.Empty;

        char prev = chars[0];
        int currentAmount = 1;
        if (chars.Length == 1) ret += chars[0];

        for (int i = 1; i < chars.Length; i++)
        {
            var current = chars[i];
            if (current != prev) //new char
            {
                ret += prev;
                if (currentAmount != 1)
                {
                    ret += currentAmount;
                }

                prev = current;
                currentAmount = 1;
                if (i == chars.Length - 1)
                {
                    ret += prev;
                }
            }
            else
            {
                currentAmount++;
                if (i == chars.Length - 1)
                {
                    ret += prev;
                    if (currentAmount > 1) ret += currentAmount;
                }
            }
        }
            

        for (var i = 0; i < ret.Length; i++)
        {
            chars[i] = ret[i];
        }

        return ret.Length;
    }
}