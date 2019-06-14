using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs_90_view_practice.Models
{
    public static class Practice
    {
        public static List<string> list = new List<string>();
    }
    public class Nonstatic
    {
        public List<string> list { get; set; }
        public Nonstatic()
        {
            list = new List<string>();
        }
    }
}
