using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labs_86_async
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[] { "a", "b" };
            File.WriteAllLines("output.txt", strings);
            File.AppendAllLines("output.txt", strings);
            File.WriteAllText("output.txt", "some data here");
            ReadFileAsync();
            Console.WriteLine("Program has finished");
        }

        static async void ReadFileAsync()
        {
            
        }
    }
}
