using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_106_Classes
{
    class Program
    {
        static List<string> arr_str = new List<string>();
        static List<char> arr_char = new List<char>();
        static List<int> arr_int = new List<int>();
        static void Main(string[] args)
        {
            for(int j=0; j<=10; j++)
            {
                arr_str.Add("xxxTentacion");
                arr_char.Add('F');
                arr_int.Add(34);
            }
        }
    }
    abstract class Increm
    {
        public int x = 0;
        int Prop { get; set; }
        public Increm()
        {
            this.Prop = 23;
        }
        void DoThis()
        {
            x++;
        }
        int Over1(int a, int b)
        {
            return a + b;
        }
        int Over1(int a, int b, int c)
        {
            return a + b + c;
        }
        public abstract void Afunc();
    }
    class Increm2 : Increm
    {
        void DoThis()
        {
            //int x = 0;
            x += 2;
            Console.WriteLine(x);
        }
        public override void Afunc()
        {
            Console.WriteLine("Abstracted");
        }
    }

    public class ASCII
    {
        static public int value(string asc, int j)
        {
            int i = (int)asc[j];
            return i;
        }
    }

    interface Test
    {
        int exp(int a, int b);
    }
    public class ExpTest: Test
    {
        public int exp(int a, int b)
        {
            for (int i = 1; i <= b; i++)
            {
                a *= a;
            }
            return a;
        }
    }
}
