using System;
using System.Diagnostics;

namespace ProcessWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from ProcessWrapper!");

            StartProcess(@"C:\Users\cluster\Desktop\t\testRun\", new int[] {4,5});

            Console.WriteLine("Exiting programm..");
        }

        private static void StartProcess(String appdir, int[] processors)
        {
            Console.WriteLine("Starting Console App at"+appdir);
            Process process = new Process();
            process.StartInfo.WorkingDirectory = appdir;
            process.StartInfo.FileName = appdir + "Parallel_Tumor_ModellingConsoleApp.exe";
            process.StartInfo.Arguments = appdir + "inputParams.txt";
            process.Start();
            
            //Set Affinity
            int bitMask = 0;
            foreach (var item in processors)
            {
                bitMask = bitMask | (1 << item - 1);
                Console.WriteLine("Processor #{0} was selected for affinity.", item);
            }
            long AffinityMask = (long)process.ProcessorAffinity;
            AffinityMask &= bitMask;
            process.ProcessorAffinity = (IntPtr)AffinityMask;

            process.WaitForExit();
        }

     
    }
}
