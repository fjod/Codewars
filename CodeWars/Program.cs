using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        private static bool _returnCompletedTask;

        private class MyAwaitable
        {
            public MyAwaiter GetAwaiter() => new MyAwaiter();
        }

        private class MyAwaiter : INotifyCompletion
        {
            public bool IsCompleted
            {
                get
                {
                    Console.WriteLine("IsCompleted called.");
                    return _returnCompletedTask;
                }
            }
            public int GetResult()
            {
                Console.WriteLine("GetResult called.");
                return 5;
            }
            public void OnCompleted(Action continuation)
            {
                Console.WriteLine("OnCompleted called.");
                continuation();
            }
        }

        class test
        {
            public event Action<int,string> InputReceived;
        }
       
        static async Task Main(string[] args)
        {
            test source = new test();
            Task<string> WaitInput()
            {
                var tcs = new TaskCompletionSource<string>();
                source.InputReceived += (o, args) => tcs.SetResult(args);
                return tcs.Task;
            }

            var q = await WaitInput();
            Console.WriteLine("Before first await");
            _returnCompletedTask = true;
            var res1 = await new MyAwaitable();
            Console.WriteLine(res1);
        
            Console.WriteLine("Before second await");
            _returnCompletedTask = false;
            var res2 = await new MyAwaitable();
            Console.WriteLine(res2);
            
            

            Console.WriteLine("Hello World!");

            var phoneTest = PhoneNumber.Create(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0});
            Console.WriteLine(phoneTest);

            var morseTest = MorseCode.Convert(".... . -.--   .--- ..- -.. .");
            Console.Write(morseTest);
            Console.ReadKey();
        }
    }

   
}