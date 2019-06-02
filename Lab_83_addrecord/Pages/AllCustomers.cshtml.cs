using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_83_addrecord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Lab_83_addrecord.Pages;

namespace Lab_83_addrecord.Pages
{
    public class AllCustomersModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers = new List<Customer>();
        [BindProperty]
        public Customer customer { get; set; }
        public int current = 1;
        public bool load = false;
        static int length()
        {
            using (var db = new Northwind())
            {
                if (db.Customers.Count() % 10 == 0)
                    return db.Customers.Count() / 10;
                return db.Customers.Count()/10+1;
            }
        }
        public int last = length();
        public AllCustomersModel(Northwind InjectedContext)
        {
            db = InjectedContext;
        }
        /*public void OnGet()
        {
            customers = db.Customers.Skip(20).Take(10).ToList();
        }*/

        public IActionResult OnGet()
        {
            customers = db.Customers.Skip((current - 1) * 10).Take(10).ToList();
            System.Diagnostics.Debug.WriteLine($">>>> {Request.Query["page"]}");
            if (ModelState.IsValid && Request.Query["page"]!=StringValues.Empty)
            {
                    current = Int32.Parse(Request.Query["page"]);
                    System.Diagnostics.Debug.WriteLine($"true {current}");
                    if(current!=0 && current<=last)
                        customers = db.Customers.Skip((current - 1) * 10).Take(10).ToList();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }
    }
}