using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Labs_task_wait
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            var taskArray = new Task[3];
            taskArray[0] = Task.Run(() => {
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"Task 01 finishing at {s.ElapsedTicks}");
            });
            taskArray[1] = Task.Run(() => {
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"Task 02 finishing at {s.ElapsedTicks}");
            });
            taskArray[2] = Task.Run(() => {
                System.Threading.Thread.Sleep(500);
                Console.WriteLine($"Task 03 finishing at {s.ElapsedTicks}");
            });
            var singleTask = Task.Run(() => { Console.WriteLine($"Single task finishing at {s.ElapsedTicks}"); });
            singleTask.Wait();
            Task.WaitAny(taskArray);
            Console.WriteLine($"FInished at{s.ElapsedTicks}");
            Console.ReadLine();
        }
    }
}
