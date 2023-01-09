using System;

namespace CodeWars
{
    class Program
    {
      
        public static void ReverseString(char[] s)
        {
            RevSpan(s);
        }

        public static void RevSpan(Span<char> s)
        {
            if (s.Length <=1) return;
            (s[0], s[^1]) = (s[^1 ], s[0]);
            var span = s.Slice(1, s.Length - 2);
            RevSpan(span);
        }
   

     

        static void Main(string[] args)
        {
            var input = new[] {'h', 'e', 'l', 'l', 'o'};
           ReverseString(input);
           ReverseString(input);
        }
    }
}