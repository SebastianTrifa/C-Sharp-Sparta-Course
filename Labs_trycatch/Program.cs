using System;

namespace Labs_trycatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            int i = 0;
            try
            {
                n = n / i;
            }
            catch
            {
                Console.WriteLine("Divided by 0");
                throw;
            }
        }
    }
}
