using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_hw_01
{
    class Program
    {
        static void Main(string[] args)
        { 
        }
    }
    public class Collections
    {
        public static int Collect(int a, int b, int c, int d, int e)
        {
            int sum = 0;
            Queue<int> queuo = new Queue<int>();
            Stack<int> stacko = new Stack<int>();
            List<int> listo = new List<int>() { 12, 16, 6, 45, 13};
            foreach (int i in listo)
            {
                stacko.Push(i * 2);
            }
            foreach (int i in stacko)
            {
                queuo.Enqueue(i + 10);
            }
            foreach (int i in queuo)
            {
                sum += i;
            }
            return sum;
        }
    }
}
