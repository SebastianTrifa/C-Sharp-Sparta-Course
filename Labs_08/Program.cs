using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs_08
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }



    public class TwoToOne
    {

        public static string Longest(string s1, string s2)
        {
            var longest = "";
            var builder = new System.Text.StringBuilder();
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            foreach (char a in alpha)
            {
                //check a in either string
                if (s1.Contains(a) || s2.Contains(a))
                {
                    builder.Append(a);
                }
            }
            longest = builder.ToString();
            return longest;
        }
    }
}
