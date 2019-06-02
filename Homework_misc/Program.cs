using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_misc
{
    class Program
    {
        enum Week { Monday, Tueday, Wednesday, Thursday, Friday, Saturday, Sunday};
        static void Main(string[] args)
        {
            Console.WriteLine((int)Week.Friday);
            string exer;
            try
            {
                checked {
                    int c = int.MaxValue;
                    c++;
                }
            }
            catch(System.OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        struct Point
        {
            int x { get; set; }
            int y { get; set; }
            int z { get; set; }
            Point(int a, int b, int c)
            {
                this.x = a;
                this.y = b;
                this.z = c;
            }
        }
    }
}
