using System;
using System.Collections.Generic;

namespace Labs_abstract
{
    class Program
    {
        static List<int> listex = new List<int>();
        static List<string> liststr = new List<string>();
        static void Main(string[] args)
        {
            listex.Add(5);
            listex.Add(2);
            listex.Remove(2);
            liststr.Add("ex");
            liststr.Add("toremove");
            liststr.Remove("toremove");
            foreach(int i in listex)
                Console.WriteLine(i);
            foreach(string str in liststr)
                Console.WriteLine(str);
        }
    }
}
