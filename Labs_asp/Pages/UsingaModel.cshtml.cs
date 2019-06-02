using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Labs_asp.Pages
{
    public class UsingaModelModel : PageModel
    {
        public string Property01 { get; set; } = "Default Value";
        //onget not a constructor : HTML Get request
        public void OnGet()
        {
            Property01 = "Here is data passed from the page model into our viewmodel";
        }
    }
}