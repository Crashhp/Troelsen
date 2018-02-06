using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsoleIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Basic Console I/O *****");
            GetUserData();
            FormatNumericalData();
            DisplayMessage();
            LocalVarDeclarations();
            NewingDataTypes();
            Console.ReadLine();
        }

        private static void GetUserData()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            Console.Write("Please enter your age: ");
            string userAge = Console.ReadLine();

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);
            Console.ForegroundColor = prevColor;

            Console.WriteLine();
        }

        static void FormatNumericalData()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d9}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);

            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);

            Console.WriteLine();
        }

        static void DisplayMessage()
        {
            string userMessage = string.Format("100000 in hex is {0:x}", 100000);

            System.Windows.MessageBox.Show(userMessage);
        }

        static void LocalVarDeclarations()
        {
            Console.WriteLine("=> Data Declarations:");
            int myInt = 0;
            string myString;
            myString = "This is my character data";
            bool b1 = true, b2 = false, b3 = b1;
            System.Boolean b4 = false;
            Console.WriteLine("Your data: {0}, {1}, {2}, {3}, {4}, {5}",
                myInt, myString, b1, b2, b3, b4);

            Console.WriteLine();
        }

        static void DefaultDeclarations()
        {
            Console.WriteLine("=> Default Declarations:");
            // can't get 7.1 to work 'cause of VS2015
            // int myInt = default;
            int myInt = default(int);
        }

        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool();              // Set to false.
            int i = new int();                // Set to 0.
            double d = new double();          // Set to 0.
            DateTime dt = new DateTime();     // Set to 1/1/0001 12:00:00 AM
            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
        }
    }
}
