using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework_108_webpage.Pages
{
    public class MenuModel : PageModel
    {
        public string city;
        public void OnGet()
        {

        }

        public void London()
        {
            city = "London";
        }

        public void Mexico()
        {
            city = "Mexico";
        }

        public void Rio()
        {
            city = "Rio";
        }
    }
}