using System;
using System.Collections.Generic;

namespace Labs_hw_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Dog
    {
        List<int> arr = new List<int>();
        public int Age { get; set; }
        public int Height { get; set; }
        public Dog()
        {
        }
        public int Grow(int Age, out int height)
        {
            height = Height+5;
            return Age+1;
        }
    }
}
