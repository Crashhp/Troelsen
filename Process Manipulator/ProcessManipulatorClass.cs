using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessManipulator
{
    class ProcessManipulatorClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Processes ****\n");
            ListAllRunningProcesses();

            Console.WriteLine("***** Enter PID of process to investigate *****");
            Console.Write("PID: ");
            string str = Console.ReadLine();
            int procId = int.Parse(str);

            EnumThreadsForPid(procId);
            EnumModsForPid(procId);

            StartAndKillProcess();

            Console.ReadLine();
        }

        static void ListAllRunningProcesses()
        {
            var runningProcs = Process.GetProcesses(".").OrderBy(proc => proc.Id).Select(proc => proc);

            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PIDL {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        static void EnumThreadsForPid(int PID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(PID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the threads used by: {0}", theProc.ProcessName);

            ProcessThreadCollection theThreads = theProc.Threads;
            foreach (ProcessThread thread in theThreads)
            {
                string info = string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}", thread.Id, thread.StartTime.ToShortTimeString(), thread.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        static void EnumModsForPid(int PID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(PID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}", theProc.ProcessName);

            ProcessModuleCollection theModules = theProc.Modules;
            foreach (ProcessModule mod in theModules)
            {
                string info = string.Format("-> Module Name: {0}", mod.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("*****************************************************\n");
        }

        static void StartAndKillProcess()
        {
            Process ieProc = null;
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                ieProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.Write("— > Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();
            // Уничтожить процесс iexplore.exe.
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
