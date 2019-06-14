using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroupProject_WebPage.Models;
using Microsoft.Extensions.Primitives;

namespace GroupProject_WebPage.Pages
{
    public class UsersModel : PageModel
    {
        private SpartaModel db = new SpartaModel();
        public List<Users> users = new List<Users>();
        [BindProperty]
        public Users user { get; set; }
        public int current = 1;
        public bool load = false;
        public string email;
        static int length()
        {
            using (var db = new SpartaModel())
            {
                if (db.Users.Count() % 10 == 0)
                    return db.Users.Count() / 10;
                return db.Users.Count() / 10 + 1;
            }
        }
        public int last = length();
        public UsersModel()
        {
            //db = InjectedContext;
        }
        /*public void OnGet()
        {
            customers = db.Customers.Skip(20).Take(10).ToList();
        }*/

        public IActionResult OnGet()
        {
            if (!Global._login)
            {
                return RedirectToPage("/Login");
            }
            users = db.Users.Skip((current - 1) * 10).Take(10).ToList();
            System.Diagnostics.Debug.WriteLine($">>>> {Request.Query["page"]}");
            if (ModelState.IsValid && Request.Query["page"] != StringValues.Empty)
            {
                current = Int32.Parse(Request.Query["page"]);
                System.Diagnostics.Debug.WriteLine($"true {current}");
                if (current != 0 && current <= last)
                    users = db.Users.Skip((current - 1) * 10).Take(10).ToList();
            }
            return Page();
        }
    }
}