using System;
using System.Text;

public static class Kata
{
    public static string ExpandedForm(long num)
    {
        string numer = num.ToString();
        StringBuilder numer2 = new StringBuilder();
        for (int i = numer.Length - 1; i >= 0; i--)
        {
            numer2.Append(numer[i]);
        }
        StringBuilder result = new StringBuilder();
        foreach (char c in numer2.ToString())
        {
            int j = 1;
            if (c != '0')
            {
                result.Append(c);
                for (int i = 0; i < j; i++)
                {
                    result.Append("0");
                }
                result.Append(" + ");
            }
            j++;
        }
        return result.ToString();
    }
}