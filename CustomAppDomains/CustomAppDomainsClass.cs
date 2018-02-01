using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomAppDomains
{
    class CustomAppDomainsClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom AppDomains *****\n");
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.ProcessExit += (o, s) =>
            {
                Console.WriteLine("Default AppDomain has been unloaded!");
            };
            ListAllAssembliesInAppDomain(defaultAD);
            MakeNewAppDomain();
            Console.ReadLine();
        }

        private static void MakeNewAppDomain()
        {
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o, s) =>
            {
                Console.WriteLine("The second AppDomain has been unloaded!");
            };
            try
            {
                newAD.Load("Interop.OPCAutomation");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            ListAllAssembliesInAppDomain(newAD);
            AppDomain.Unload(newAD);
        }

        private static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            var loadedAssemblies = ad.GetAssemblies().OrderBy(ass => ass.GetName().Name).Select(ass => ass);
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n", ad.FriendlyName);
            foreach (Assembly ass in loadedAssemblies)
            {
                Console.WriteLine("-> Name: {0}", ass.GetName().Name);
                Console.WriteLine("-> Version: {0}", ass.GetName().Version);
            }
        }
    }
}
