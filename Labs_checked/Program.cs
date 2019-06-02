using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_checked
{
    class Program
    {
        static void Main(string[] args)
        {
            var largenumber = int.MaxValue;
            Console.WriteLine(largenumber);
            largenumber++;
            Console.WriteLine(largenumber);
            largenumber++;
            Console.WriteLine(largenumber);
            largenumber++;
            Console.WriteLine(largenumber);
            largenumber++;

            checked
            {
                var bignumver = int.MaxValue;
            }
            var hugenumber = double.MaxValue;
            Console.WriteLine(hugenumber);
            var hugenumber2 = decimal.MaxValue;
            Console.WriteLine(hugenumber2);
        }
    }
}
