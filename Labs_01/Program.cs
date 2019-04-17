using System;

namespace Labs_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write Line");
            Console.WriteLine("Printing Out arguments array");
            System.Threading.Thread.Sleep(5000);
            foreach(string item in args)
            {
                Console.WriteLine("Your item is" + item);
            }
        }
    }
}
