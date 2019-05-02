using System;
using System.Numerics;

public class TotalIncreasingOrDecreasingNumbers
{
    public static BigInteger TotalIncDec(int x)
    {
        BigInteger[] asc = new BigInteger[] { 44, 35, 27, 20, 14, 9, 5, 2 };
        int j = 1;
        BigInteger n = new BigInteger(0);
        while (j != x)
        {
            n += Calculate(j, ref asc);
            j++;
        }
        return n;
    }
    public static BigInteger Calculate(int x, ref BigInteger[] asc)
    { 
        BigInteger[] temp = new BigInteger[8];
        int j = 1;
        BigInteger n = new BigInteger(0);
        BigInteger nine = new BigInteger();
        if (x == 0)
            n = 1;
        if (x == 1)
            n = 10;
        if (x == 2)
            n = 100;
        if (x == 3)
        {
            nine = 55;
            foreach (BigInteger m in asc)
                n += 2 * m;
            n += nine;
        }
        if (x > 3)
        {
            BigInteger lower = new BigInteger();
            foreach (BigInteger m in asc)
                lower += m + 1;
            for (int i = 10; i < 90; i++)
            {
                if (i % 10 <= i / 10&& i % 10!=9)
                {
                    n += 2 * asc[i % 10];
                    temp[i / 10] += asc[i % 10];
                }
                if (i % 10 <= i / 10 && i % 10 == 9)
                {
                    n += nine;
                }
            }
            nine += lower / 2 + nine + 10;
            for (int i = 1; i <= 8; i++)
                asc[i] = temp[i];
        }
        return n-9;
    }
}