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
            public bool DetectCapitalUse(string word)
            {
                if (word.Length == 1)
                {
                    return true;
                }

                if (char.IsUpper(word[0]) && char.IsUpper(word[1]))
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (char.IsLower(word[i]))
                        {
                            return false;
                        }
                    }

                    return true;
                }


                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsUpper(word[i]))
                    {
                        return false;
                    }
                }


                return true;
            }

            static void Main(string[] args)
            {
                int[] arr = new int[] {1, 3, 5, 7, 9};
                var q = MaxScore("0100");
            }
        }
    }
}