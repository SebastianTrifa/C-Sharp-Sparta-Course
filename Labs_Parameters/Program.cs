using System;
using System.Collections.Generic;

namespace Labs_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis(10, "hello world");
            var listoutput = BuildAList(100, 200, 300, out bool longlist);
            Console.WriteLine(longlist);
        }
        static void DoThis(int x, string y)
        {
            Console.WriteLine(x + " " + y);
        }
        static List<int> BuildAList(int x, int y, int z, out bool isLongList)
        {
            var list = new List<int>();
            list.Add(x);
            list.Add(y);
            list.Add(z);
            if (list.Count > 10)
                isLongList = true;
            else
                isLongList = false;
            return list;
        }
    }
}
