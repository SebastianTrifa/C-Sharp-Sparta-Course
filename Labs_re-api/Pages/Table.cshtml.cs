using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labs_ReDoASP.Pages
{
    public class TableModel : PageModel
    {
        public List<string> cities = new List<string>() { "Alexandria", "Tyr", "Ctesiphon", "Persepolis", "Halicarnassus" };
        public void OnGet()
        {

        }
    }
}