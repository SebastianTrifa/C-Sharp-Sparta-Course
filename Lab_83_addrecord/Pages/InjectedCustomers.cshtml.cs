using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_83_addrecord.Models;

namespace Lab_83_addrecord.Pages
{
    public class InjectedCustomersModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers;
        [BindProperty]
        public Customer customer { get; set; }
        public InjectedCustomersModel(Northwind InjectedContext)
        {
            db = InjectedContext;
        }
        public void OnGet()
        {
            customers = db.Customers.Skip(20).Take(10).ToList();
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }
    }
}