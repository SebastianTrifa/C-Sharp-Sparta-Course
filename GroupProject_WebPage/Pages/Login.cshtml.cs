using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroupProject_WebPage.Models;
using GroupProject_WebPage.Pages;

namespace GroupProject_WebPage.Pages
{
    public class LoginModel : PageModel
    {
        private SpartaModel db = new SpartaModel();
        public void LoggedOut()
        {
            Global._login = false;
        }
        public IActionResult OnPost()
        {
            if (db.Users.Where(c => c.Email == Request.Form["email"]).Count() != 0 && db.Users.Where(c => c.Email == Request.Form["email"]).First().Password == Request.Form["password"])
            {
                Global._login = true;
                return RedirectToPage("/Users");
            }
            return Page();
        }
    }
}