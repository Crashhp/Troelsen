using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddWithThreadsUpdate
{
    class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            AddAsync();
            Console.WriteLine("Main Thread is out of AddAsync()");
            Console.ReadLine();
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("***** Adding with Thread objects *****\n");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            AddParams ap = new AddParams(10, 10);

            await Sum(ap);

            Console.WriteLine("Other thread is done!");
        }

        static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                if (data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                    AddParams ap = (AddParams)data;
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
                        Thread.Sleep(2000);
                    }
                }
            });
        }
    }
}

