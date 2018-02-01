using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectContextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Context *****\n");
            SportCar sport = new SportCar();
            Console.WriteLine();

            SportCar sport2 = new SportCar();
            Console.WriteLine();
            SportsCarTS synchroSport = new SportsCarTS();
            Console.ReadLine();
        }
    }
}
