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
        public static int NumTilePossibilities(string tiles)
        {
            HashSet<string> possibilities = new HashSet<string>();
            helper(tiles, possibilities, string.Empty);
            return possibilities.Count;
        }

        
        private static void helper(string tiles, HashSet<string> possibilities, string current)
        {
            if (current != string.Empty) possibilities.Add(current);

            for (int i = 0; i < tiles.Length; i++)
            {
                var letter = tiles[i];
                possibilities.Add(letter.ToString());
                var leftTiles = tiles.ToList();
                leftTiles.RemoveAt(i);
                
                var left = leftTiles.Aggregate(string.Empty, (s, c) => s + c);
                if (left.Any())  possibilities.Add(left);
                helper(left, possibilities, current + letter);
            }
        }


        static void Main(string[] args)
        {
       
           // var q = MaxProfit(new []{7,1,5,3,6,4});
            var q = NumTilePossibilities("AAB");
         
        }
    }
}