using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labs_ReDoASP.Pages
{
    public class AnotherPageModel : PageModel
    {
        public string Property { get; set; }
        public void OnGet()
        {
            Property = "Lorem ipsum";
        }
    }
}