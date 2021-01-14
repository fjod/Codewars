using System;

namespace CodeWars
{
    class Program
    {
        class Holder
        {
            public int Value;
        }

        static void Test1(Holder h)
        {
            h = new Holder() {Value = 111}; //wont work
            //h.Value = 555; //will work
        }
        static void Test1(ref Holder h)
        {
            h = new Holder() {Value = 111}; //will work
        }
        static void Test2(in int h)
        {
            Console.WriteLine(h.ToString());
        }
        static void Main(string[] args)
        {
            int h = 50;
            Test2(in h);
            Holder a = new Holder() {Value = 10};
            Console.WriteLine(a.Value);
            Test1(a);
            Console.WriteLine(a.Value);
            Test1(ref a);
            Console.WriteLine(a.Value);
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