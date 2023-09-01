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
        static void Main(string[] args)
        {
            var a = MinTimeToType("bza");
            Console.Write(1);
        }
        
        static List<char> letters = new() {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        public static int MinTimeToType(string word)
        {
            int pointer = 0;
            int counter = 0;
            for (int i = 0; i < word.Length; i++)
            {
                var current = word[i];
                var fromPointer = letters[pointer];
                if (current != fromPointer)
                {
                    var targetIndex = letters.IndexOf(current);
                    var diff = Math.Abs(pointer - targetIndex);
                    counter += Math.Min(diff, 26 - diff);
                    pointer = targetIndex;
                }
                counter += 1;
            }

            return counter;
        }
    }
}