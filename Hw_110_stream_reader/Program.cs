using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hw_110_stream_reader
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] strings = new string[] { "a", "b"};
            Reader.Read("text.txt");
            Reader.Write(strings, "output.txt");
            File.WriteAllLines("output.txt", strings);
            File.AppendAllLines("output.txt", strings);
            File.WriteAllText("output.txt", "some data here");
        }
    }

    static public class Reader
    {
        static public (int, string) Read(string path)
        {
            StreamReader reader = new StreamReader(path);
            string oneLine = null;
            string result = "";
            int numlines = 0;
            while (!reader.EndOfStream)
            {
                if ((oneLine = reader.ReadLine().Trim()) != "")
                    result += oneLine;
                numlines++;
                result = result.Replace(" ","");
            }
            return (numlines, result);
        }

        static public void Write(string[] strings, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach(var c in strings)
                {
                    writer.WriteLine(c.ToString());
                }
            }
        }
    }
}
