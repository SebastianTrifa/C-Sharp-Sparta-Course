using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_90_MVC_core.Models
{
    public class ListClass
    {
        public List<string> list { get; set; }
        public ListClass()
        {
            list = new List<string>();
            list.Add("first");
            list.Add("second");
        }
    }
}
