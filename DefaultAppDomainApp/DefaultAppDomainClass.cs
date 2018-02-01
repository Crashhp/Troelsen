using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DefaultAppDomainApp
{
    class DefaultAppDomainAppClass
    {
        static void Main(string[] args)
        {
            InitAD();
            Console.WriteLine("***** Fun with the default AppDomain *****\n");
            DisplayDADStats();
            ListAllAssembliesInAppDomain();
            Console.ReadLine();
        }

        private static void DisplayDADStats()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }

        private static void ListAllAssembliesInAppDomain()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            var loadedAssemblies = defaultAD.GetAssemblies().OrderBy(ass => ass.GetName().Name).Select(ass => ass);
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);
            foreach (Assembly ass in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", ass.GetName().Name);
                Console.WriteLine("-> Version: {0}", ass.GetName().Version);
            }
        }

        private static void InitAD()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
            {
                Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
            };
        }
    }
}
