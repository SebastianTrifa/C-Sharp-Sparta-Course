using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            for(i = 1; i<= 100; i++)
                {
                if (i % 3 == 0)
                {
                    Console.Write("fizz");
                }
                if (i % 5 == 0)
                {
                    Console.Write("buzz");
                }
                if (i % 3 != 0 && i % 5 != 0)
                {
                    Console.Write("{0}",i);
                }
                Console.Write("\n");
                }
        }
    }
}
