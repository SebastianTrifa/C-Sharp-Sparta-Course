using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_83_addrecord.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace Lab_83_addrecord.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers;
        public Customer customer = new Customer();
        public DeleteCustomerModel(Northwind DeleteContext)
        {
            db = DeleteContext;
        }
        public IActionResult OnGet()
        {
            customers = db.Customers.Take(10).ToList();
            if (Request.Query["customerID"] != StringValues.Empty)
            {
                string cid = Request.Query["customerID"];
                customer = db.Customers.Where(c => c.CustomerID == cid).ToList().First();
                System.Diagnostics.Debug.WriteLine($">>>> custID {Request.Query["customerID"]}");
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }
    }
}