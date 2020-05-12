using System;

namespace CodeWars
{
    public static class Wub
    {
        static string search = "WUB"; //remove all strings like WUB from input

        public static string Remove(string input)
        {
            string ret = input;
            do
            {
                ret =ret.Replace(search, String.Empty);
            } while (ret.Contains(search));

            return ret.Trim().Replace("   "," ").Replace("  "," ");
        }
        
    }
}