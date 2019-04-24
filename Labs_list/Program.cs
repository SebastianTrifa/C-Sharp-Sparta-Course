using System;
using System.Collections.Generic;

namespace Labs_list
{
    class Program
    {
        static List<int> list01 = new List<int>();
        static List<int> list02 = new List<int>();
        static Stack<int> stack01 = new Stack<int>();

        static void Main(string[] args)
        {
            list01.Add(10);
            list02.Add(20);
            foreach (var item in list01)
            {
                Console.WriteLine(item);
            }
            list01.ForEach(item => Console.WriteLine(item));
            DoThis();
            stack01.Push(10);
            stack01.Push(20);
            stack01.Push(30);
            Console.WriteLine(stack01.Contains(30));
            Console.WriteLine(stack01.Pop());
        }

        static void DoThis()
        {
            int x = 20;
            int y = 10;
            DoThat();
        }

        static void DoThat()
        {

        }

    }
}
