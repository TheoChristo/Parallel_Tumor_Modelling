using System;
using System.IO;

namespace Parallel_Tumor_Modelling_ConsoleApp
{
    class Program
    {
        private static double[] khy = new double[] { 6.5e-11, 6.5e-11 };
        private static double muLame = 6e4;
        private static double Svin = 7000;
        private static double[] lp = new double[] { 2.7e-12, 2.7e-12 };
        private static double Dcell = 5.4e-3;

        static void Main(string[] args)
        {
            //Todo: File name assigned by function argument
            ParseFile("inputParams.txt");
            Console.WriteLine("Creating Tumor Model...");
            Console.WriteLine("khy={" + khy[0] + "," + khy[1] + "} | muLame[0]=" + muLame + " | Svin=" + Svin + " | " + "lp={" + lp[0] + "," + lp[1] + "} | Dcell[0]=" + Dcell);
            var TumorModel = new TumorModelling(khy, muLame, Svin, lp, Dcell);
            Console.WriteLine("Running Tumor Model...");
            TumorModel.RunModel();
        }

        static void ParseFile(string filename)
        {
            Console.WriteLine("Reading File...");
            StreamReader reader = File.OpenText(filename);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split('=');
                string id = items[0].Trim();
                double val = double.Parse(items[1]);

                switch (id)
                {
                    case "khy":
                        khy[0] = val;
                        khy[1] = val;
                        break;
                    case "muLame":
                        muLame = val;
                        break;
                    case "Svin":
                        Svin = val;
                        break;
                    case "lp":
                        lp[0] = val;
                        lp[1] = val;
                        break;
                    case "Dcell":
                        Dcell = val;
                        break;
                    default:
                        throw new ArgumentException("Unknown identifier ", nameof(id));
                }


            }
        }
    }
}
