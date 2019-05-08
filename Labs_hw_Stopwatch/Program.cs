using System;
using System.Diagnostics;

namespace Labs_hw_Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = 0, limit=20, time=0 ;
            while (time < limit * 1000)
            {
                power++;
                time = CountNumber.CountNow(power, limit);
                Console.WriteLine(time);
            }
            Console.WriteLine(power);
        }
    }

    static public class CountNumber
    {
        static public int CountNow(int power, int maxtime)
        {
            Stopwatch stopWatch = new Stopwatch();
            int time = 0;
            TimeSpan ts = new TimeSpan();
            stopWatch.Start();
            double num = Math.Pow(10, power);
                for (double i = 0; i <= num; i++)
                {

                }
                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                time = ts.Seconds * 1000 + ts.Milliseconds;
            stopWatch.Stop();
            return time;
        }
    }
}
