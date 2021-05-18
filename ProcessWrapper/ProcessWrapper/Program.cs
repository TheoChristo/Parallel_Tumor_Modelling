using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace ProcessWrapper
{
    class Program
    {
        private static readonly List<int[]> processorList = new List<int[]>(new[]
        {
            //new int[] { 1, 2 },
            //new int[] { 3, 4 },
            new int[] { 5, 6 }
        });
        private static Queue<String> processQ = new Queue<string>(new[] {
            @"C:\Users\cluster\Desktop\t\testRun1\",
            @"C:\Users\cluster\Desktop\t\testRun2\"
        }); 
        private static List<Tuple<String, int[]>> runningProcesses;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Process Scheduler!");

            runningProcesses = new List<Tuple<string, int[]>>();
            //Start a process to each available proc
            foreach (var item in processorList)
            {
                runningProcesses.Add(new Tuple<string, int[]>(processQ.Dequeue(), item));
                StartProcess(runningProcesses[runningProcesses.Count-1].Item1,
                            runningProcesses[runningProcesses.Count - 1].Item2);
            }
            StartCrawler();
            Console.WriteLine("Exiting programm..");
        }

        private static void StartProcess(String appdir, int[] processors)
        {
            Console.WriteLine("Starting process " + appdir); 
            Process process = new Process();
            process.StartInfo.WorkingDirectory = appdir;
            process.StartInfo.FileName = appdir + "Parallel_Tumor_ModellingConsoleApp.exe";
            process.StartInfo.Arguments = appdir + "inputParams.txt";
            process.Start();
            
            //Set Affinity
            int bitMask = 0;
            foreach (var item in processors) bitMask = bitMask | (1 << item - 1);
            long AffinityMask = (long)process.ProcessorAffinity;
            AffinityMask &= bitMask;
            process.ProcessorAffinity = (IntPtr)AffinityMask;
        }

        public static void StartCrawler()
        {
            while(processQ.Count>0)
            {
                Thread.Sleep(10000);
                foreach(var proc in runningProcesses)
                {
                    if (File.Exists(proc.Item1+"completed.txt"))
                    {
                        Console.WriteLine("Process "+proc.Item1+" completed.");
                        runningProcesses.Add(new Tuple<string, int[]>(processQ.Dequeue(), proc.Item2));
                        runningProcesses.Remove(proc);
                        StartProcess(runningProcesses[runningProcesses.Count - 1].Item1,
                                    runningProcesses[runningProcesses.Count - 1].Item2);
                        break;
                    }
                }

            }
        }
     
    }
}
