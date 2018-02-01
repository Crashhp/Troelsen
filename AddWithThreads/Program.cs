﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddWithThreads
{
    class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("***** Adding with Thread objects *****\n");
            Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
            AddParams ap = new AddParams(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");
            Console.ReadLine();
        }

        static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("ID of thread in Add(): {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);

                waitHandle.Set();
            }
        }
    }
}
