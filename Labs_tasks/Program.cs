using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Labs_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            var t = new Task(
                () => {
                    Console.WriteLine($"Starting Task Now at time " + s.ElapsedTicks);
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine($"Finishing task at the time {s.ElapsedTicks}");
                }
            );

            t.Start();
            Console.WriteLine($"Program has finished at the time {s.ElapsedTicks}");
            var t02 = Task.Run(
                () =>
                {
                    Console.WriteLine(s.ElapsedTicks);
                }
            );

            var t03 = Task.Run(
                new Action(Method01)
                );

            var t04 = Task.Run(
                delegate
                {
                    Console.WriteLine($"In task with anon delegate at{s.ElapsedTicks}");
                }
                );

            var t05 = Task.Factory.StartNew(() => Console.WriteLine(""));

            Console.ReadLine();
        }

        static void Method01()
        {
            Console.WriteLine("In Method 1");
        }
    }
}
