using System;
using Labs04;

namespace Labs05_usedll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading from another library");
            var item = new Sebastian();
            item.Sebdata = "some data here";
            Console.WriteLine(item.Sebdata);
            Console.WriteLine(item.Sebdatafixed);
        }
    }
}
