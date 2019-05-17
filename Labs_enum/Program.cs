using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_enum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Parent
    {
        public virtual void DoThis()
        {
            Console.WriteLine("Parent");
        }
    }
    class Child : Parent
    {
        public override void DoThis()
        {
            base.DoThis();
            Console.WriteLine("Child");
        }
    }
}
