using System;
using System.Text;

public class Kata
{
    public static string Rot13(string message)
    {
        string alpha = "abcdefghijklmnopqrstuvwxyz";
        bool upper=false;
        StringBuilder cypher = new StringBuilder();
        foreach (char c in message)
        {
            upper=!alpha.Contains(c.ToString());
            if (alpha.Contains(char.ToLower(c).ToString()))
            {
                int i = alpha.IndexOf(char.ToLower(c));
                i += 13;
                i %= 26;
                Console.WriteLine();
                if (upper)
                    cypher.Append(char.ToUpper(alpha[i]));
                else
                    cypher.Append(c);
            }
            else
                cypher.Append(c);
        }
        return cypher.ToString();
    }
}