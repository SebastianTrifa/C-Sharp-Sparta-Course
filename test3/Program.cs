using System;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] asc = new int[] { 165, 120, 84, 56, 35, 20, 10, 4};
            int[] desc = new int[] { 220, 165, 120, 84, 56, 35, 20, 10, 4 };
            int s = 0, s2 = 0;
            for (int i = 0; i <= 7; i++)
            {
                s2 += (2 * (i + 1) + 1) * asc[i];
                /*for (int j = i; j <= 8; j++)
                {
                    s += asc[j];
                    s += desc[j];
                }*/
            }
                s2 += 9;
            s2 += 220;
            Console.WriteLine(s);
            Console.WriteLine(s2);
        }
    }
}
