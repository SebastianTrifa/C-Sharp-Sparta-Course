using System;
using System.IO;

namespace Labs_86_async2
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
            string oneLine;
            using (var reader = new StreamReader("output.txt"))
            {
                while (true)
                {
                    oneLine = await reader.ReadLineAsync();
                    if (oneLine == null)
                        break;
                    Console.WriteLine(oneLine);
                }
            }
        }
    }
}
