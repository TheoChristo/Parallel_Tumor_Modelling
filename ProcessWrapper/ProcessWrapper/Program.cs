using System;
using System.Diagnostics;

namespace ProcessWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from ProcessWrapper!");
            Process process = new Process();
            process.StartInfo.FileName = "Parallel_Tumor_ModellingConsoleApp.dll";
            process.StartInfo.Arguments = "inputParams.txt";

            //long AffinityMask = (long)process.ProcessorAffinity;
            ////AffinityMask &= 0x000F; // use only any of the first 4 available processors
            ////process.ProcessorAffinity = (IntPtr)AffinityMask;

            //ProcessThread Thread = process.Threads[0];
            //AffinityMask = 0x0002; // use only the second processor
            //Thread.ProcessorAffinity = (IntPtr)AffinityMask;
            ////process.Start();
            ////process.WaitForExit();// Waits here for the process to exit.

        }
    }
}
