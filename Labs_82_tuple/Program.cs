using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_82_tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            Console.WriteLine($"int is {AlsoDoThis()}");
            var output1 = TupleFunc();
            var output2 = TupleFunc2();
        }

        static void DoThis()
        {
            Console.WriteLine("I am doing nothing");
        }

        static int AlsoDoThis()
        {
            return -1;
        }

        static (int, string) TupleFunc()
        {
            int i = 1;
            string str = "next";
            return (i, str);
        }

        static (int num1, string str2) TupleFunc2()
        {
            int i = 1;
            string str = "next";
            return (i, str);
        }
    }
}
