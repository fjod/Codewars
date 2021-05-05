using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace CodeWars
{
   
    class Program
    {
        
        static string ReorderSpaces(string text)
        {
            double spacesCount = text.Count(c => c == ' ');
            var splittedWords = text.Split(" ").Where(s => !String.IsNullOrWhiteSpace(s));
            var wordsCount = splittedWords.Count();
            var maximizedCount = (int)(spacesCount / (wordsCount-1));
            if (wordsCount == 1)
                maximizedCount = 0;
            StringBuilder sb = new StringBuilder();

            int counter = 0;
            foreach (var word in splittedWords)
            {
                sb.Append(word);
                if (counter < wordsCount-1)
                    for (int i = 0; i < maximizedCount; i++)
                    {
                        sb.Append(' ');
                    }
                counter++;
            }
            var leftSpacesAmount = spacesCount % (wordsCount - 1);
            if (wordsCount == 1)
                leftSpacesAmount = spacesCount;
            for (int i = 0; i < leftSpacesAmount; i++)
            {
                sb.Append(' ');
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            var a = ReorderSpaces("  hello");
            Console.ReadKey();
        }
    }
}

