using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_03_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=0,n;
            while(i<10){
                n = i * i + i - 1;
                Console.WriteLine("{0}",n);
                i++;
            }
            i = 0;
            do
            {
                n = i * i + i - 1;
                Console.WriteLine("{0}", n);
                i++;
            } while (i <= 10);
            for (i = 0; i < 10; i++)
            {
                n = i * i + i - 1;
                Console.WriteLine("{0}", n);
            }
            var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            foreach (int j in numbers) {
                n = i * i + i - 1;
                Console.WriteLine("{0}", n);
            }
        }
    }
}
