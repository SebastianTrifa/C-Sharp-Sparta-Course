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
            Reader.Read("text.txt");
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
    }
}
