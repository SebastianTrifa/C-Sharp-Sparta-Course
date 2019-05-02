using System;
using System.Collections.Generic;
using System.Text;
    

namespace Labs_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> numerals = new Dictionary<int, string> { [1] = "I", [5] = "V", [10] = "X", [50] = "D", [100] = "C", [500] = "D", [1000] = "M" };
            var a = new string[] { "a", "b", "c" };
            var p = new MyClass("hi", 23);
        }
    }

    class MyClass
    {
        public string Property01 { get; set; }
        public int Property02 { get; set; }
        public MyClass (string x, int y)
        {
            this.Property01= x;
            this.Property02= y;
        }
    }

}
