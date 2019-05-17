using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Labs_rabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            Rabbit.Growth(10000);
        }
    }
    public class Rabbit
    {
        public static int Growth(int population)
        {
            var csv = new StringBuilder();
            List<Rabbit> pop = new List<Rabbit>();
            Rabbit rabbit = new Rabbit();
            pop.Add(rabbit);
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            stopWatch.Start();
            int step = 0;
            //csv.AppendLine($"Time(seconds),Population");
            while (pop.Count<population)
            {
                int j = pop.Count;
                for (int i=1; i<=j; i++)
                {
                    rabbit = new Rabbit();
                    pop.Add(rabbit);
                }
                Console.WriteLine(pop.Count);
                ++step;
                //csv.AppendLine($"{step},{pop.Count}");
                while (ts.Seconds<step)
                { ts = stopWatch.Elapsed; }
            }
            ts = stopWatch.Elapsed;
            Console.WriteLine(ts.Seconds);
            //File.WriteAllText("C:\\\\c-\\rabbits.csv", csv.ToString());
            return ts.Seconds;
        }
    }
}
