using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labs_test_01
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Animal {
        public int Age { get; set; }
        public int Grow() {
            Age++;
            return Age;
        }
    }
}
