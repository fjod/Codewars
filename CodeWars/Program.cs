using System;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneTest = PhoneNumber.Create(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            Console.WriteLine(phoneTest);
            Console.ReadKey();
        }
    }
}