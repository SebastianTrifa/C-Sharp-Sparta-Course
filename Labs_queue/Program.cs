using System;
using System.Collections.Generic;

namespace Labs_queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue1 = new Queue<int>();
            queue1.Enqueue(1);
            queue1.Enqueue(2);
            queue1.Enqueue(3);
            queue1.Enqueue(4);
            queue1.Enqueue(5);
            queue1.Enqueue(6);
            queue1.Enqueue(7);
            queue1.Enqueue(8);
            queue1.Enqueue(9);
            queue1.Enqueue(10);
            Console.WriteLine(queue1.Contains(5));
            int a = queue1.Peek();
            Console.WriteLine(queue1.Peek());
            queue1.Dequeue();
            queue1.Dequeue();
            queue1.Dequeue();
            foreach(int item in queue1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
