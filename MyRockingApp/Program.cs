using System;
using System.Windows.Forms;

namespace MyRockingApp
{
    class Program
    {
        public static SportsCar MyCar { get; set; }

        static void Main(string[] args)
        {
            MyCar = new SportsCar();
            Console.Title = "My Rocking App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Welcome to My Rocking App *****");
            Console.WriteLine("*************************************");
            Console.BackgroundColor = ConsoleColor.Black;
            MessageBox.Show("My car name is " + MyCar.GetPetName());
            Console.ReadLine();
        }
    }
}
