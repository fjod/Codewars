using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWars
{
  

    class Program
    {
        
        public static bool IsLongPressedName(string name, string typed)
        {
            if (name == typed) return true;
            bool foundAtLeastOneLongPressed = false;
            int typedCurrentCharPos = 0;
            for (int i = 0; i < name.Length; i++)
            {
                var current = name[i];
                int foundCharPos = 0;
                for (int j = typedCurrentCharPos; j < typed.Length; j++) //look for same char
                {
                    if (current == typed[j])
                    {
                        foundCharPos = j;
                        break;
                    }

                    return false;
                }

                int lenOfCurrentLongPressed = 0;
                int counter = foundCharPos;
                int adder = 0;
                while (current == typed[counter])
                {
                    lenOfCurrentLongPressed++;
                    counter++;
                    adder++;
                    if (counter >= typed.Length) break;
                }

                typedCurrentCharPos = foundCharPos + adder;
                if (lenOfCurrentLongPressed > 1) foundAtLeastOneLongPressed = true;
            }

            return foundAtLeastOneLongPressed;
        }
        static void Main(string[] args)
        {
           
            
            var t = IsLongPressedName( "leelee", "lleeelee");
            Console.ReadKey();
        }
    }
}

//925. Long Pressed Name
//fails on edge case where it's not clear whether user long pressed one button 2 or 3 times
