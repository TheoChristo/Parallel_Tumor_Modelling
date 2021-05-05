using System;

namespace Parallel_Tumor_Modelling_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Creating Tumor Model...");

            //TODO: Pass arguments here
            var TumorModel = new TumorModelling();


            Console.WriteLine("Running Tumor Model...");
            TumorModel.RunModel();
        }
    }
}
