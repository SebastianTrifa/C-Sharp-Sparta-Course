using System;
using System.Collections.Generic;

namespace Labs_stackqueue_hw
{
    class Program
    {
        static Stack<string> tasks = new Stack<string>();
        static Queue<string> customers = new Queue<string>();
        static void Main(string[] args)
        {
            tasks.Push("task1");
            tasks.Push("task2");
            tasks.Push("task3");
            tasks.Pop();
            Console.WriteLine(tasks.Peek());
            customers.Enqueue("customer1");
            customers.Enqueue("customer2");
            customers.Enqueue("customer3");
            customers.Dequeue();
            Console.WriteLine(customers.Peek());
        }
    }
}
