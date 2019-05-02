using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Labs_fileop
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("text.txt", "Here is some text");
            File.AppendAllText("text.txt", "\n another line");
            File.AppendAllText("text.txt", "\n" + DateTime.Now.ToString());
            File.AppendAllText("text.txt", "\n" + DateTime.Now.ToString());
            File.AppendAllText("text.txt", "\n" + DateTime.Now.ToString());
            File.AppendAllText("text.txt", "\n" + DateTime.Now.ToString());
            File.AppendAllText("text.txt", "\n" + DateTime.Now.ToString());
            string data = File.ReadAllText("text.txt");
            Console.WriteLine(data);
            string[] dataArray = File.ReadAllLines("text.txt");
        }
    }
}
