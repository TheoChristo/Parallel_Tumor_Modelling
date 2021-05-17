using System;
using System.Diagnostics;

namespace ProcessWrapper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello from ProcessWrapper!");
            Console.WriteLine("Starting Console App...");
            String appdir = @"C:\Users\cluster\Desktop\t\testRun\";
            StartProcess(appdir);
            Console.WriteLine("Exiting programm..");
        }

        private static void StartProcess(String appdir)
        {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = appdir;
            process.StartInfo.FileName = appdir + @"Parallel_Tumor_ModellingConsoleApp.exe";
            process.StartInfo.Arguments = appdir + @"inputParams.txt";

            //long AffinityMask = (long)process.ProcessorAffinity;
            ////AffinityMask &= 0x000F; // use only any of the first 4 available processors
            ////process.ProcessorAffinity = (IntPtr)AffinityMask;

            process.Start();
            process.WaitForExit();// Waits here for the process to exit.
            Console.WriteLine("Process Finished.");
        }
    }
}
