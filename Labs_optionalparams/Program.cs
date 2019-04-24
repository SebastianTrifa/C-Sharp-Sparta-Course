using System;

namespace Labs_optionalparams
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis(10, "hi", true);
            DoThis(10, "hi");
        }
        static void DoThis(int x, string y, bool z = false)
        {

        }
    }
}
