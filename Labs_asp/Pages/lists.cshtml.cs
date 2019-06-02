using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labs_asp.Pages
{
    public class listsModel : PageModel
    {
        public List<string> items = new List<string>() { "first", "second", "third" };
        public void OnGet()
        {

        }
    }
}