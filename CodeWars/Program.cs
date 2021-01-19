using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CodeWars
{
    
 

    class Program
    {

        static  void T1(IEnumerable<object> objects)
        {
            
        }

        static void T2(IComparable<string> objects)
        {
            
        }
        public Task<string> GetStringAsync() 
        {
            return Task.FromResult(new object());
        }
       
        async ITask<List<int>> MyMethodAsync() {
            await Task.Delay(1000);
            return new[] {
                2,
                3,
                4,
            }.ToList();
        }
        static async Task Main(string[] args)
        {
            List<string> a = new List<string>();
            T1(a);
            List<object> b = new List<object>();
            T2(b);
            
            Console.ReadKey();
        }
    }

   
}