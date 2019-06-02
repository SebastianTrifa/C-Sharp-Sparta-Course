using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_lazy_loading
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[3] { 1, 2, 3 };
            var output = from item in array select item;
            array[1] = 2000;
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
