using System;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var megalist = new ArrayWrappingList<MutableStruc>();

            megalist.Add(new MutableStruc {X = 123});
            Console.WriteLine(megalist[0].X); // => 123

            ref var  reference = ref megalist[0];
            reference.X = 50;
            Console.WriteLine(megalist[0].X);
            megalist.Add(new MutableStruc {X = 345});
            //reference.X = 124;
            reference.X = 500;
            Console.WriteLine(megalist[0].X);
            
            Console.WriteLine(megalist[0].X); // => 123, not 124
            Console.WriteLine(megalist[1].X); // => 345

            Console.WriteLine("Hello World!");

            var phoneTest = PhoneNumber.Create(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            Console.WriteLine(phoneTest);

            var morseTest = MorseCode.Convert(".... . -.--   .--- ..- -.. .");
            Console.Write(morseTest);
            Console.ReadKey();
        }
    }

    struct MutableStruc
    {
        public int X;
    }

    class ArrayWrappingList<T>
    {
        private T[] _storage = Array.Empty<T>();

        public void Add(T item)
        {
            //This method allocates a new array with the specified size, copies elements from the old array to the new one,
            //and then replaces the old array with the new one. array must be a one-dimensional array.
            var newIdx = _storage.Length;
            Array.Resize(ref _storage, _storage.Length + 1);
            _storage[newIdx] = item;
        }

        public ref T this[int idx] => ref _storage[idx];
    }
}