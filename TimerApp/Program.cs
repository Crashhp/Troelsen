using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Working with Timer type *****\n");

            TimerCallback timeCB = new TimerCallback(PrintTime);
            Timer t = new Timer(timeCB, "Hello from Main()!", 0, 1000);
            Console.WriteLine("Hit key to terminate...");
            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is: {0}, Param is: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
        }
    }
}
