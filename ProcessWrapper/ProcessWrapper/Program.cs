using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace ProcessWrapper
{
    class Program
    {
        
        private static Tuple<String, int[]>[] procDic =
        { //procDic(exeLocation, processorsToUse)
            new Tuple<string, int[]>(@"C:\Users\cluster\Desktop\t\testRun1\", new int[] {1, 2}),
            new Tuple<string, int[]>(@"C:\Users\cluster\Desktop\t\testRun2\", new int[] {3, 4})
        };
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from ProcessWrapper!");

            StartProcess(procDic[0].Item1, procDic[0].Item2);

            StartProcess(procDic[1].Item1, procDic[1].Item2);

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

            //process.WaitForExit();
        }

     
    }
}
