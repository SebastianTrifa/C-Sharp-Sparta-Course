using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_83_addrecord.Models;
using Microsoft.Extensions.Primitives;

namespace Lab_83_addrecord.Pages.Shared
{
    public class AddCustomerModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers;
        public Customer customer = new Customer();
        public AddCustomerModel(Northwind AddContext)
        {
            db = AddContext;
        }
        public IActionResult OnGet()
        {
            customers = db.Customers.Take(10).ToList();
            if (Request.Query["customerID"] != StringValues.Empty)
            {
                System.Diagnostics.Debug.WriteLine($">>>> custID {Request.Query["customerID"]}");
                customer.CustomerID = Request.Query["customerID"];
                System.Diagnostics.Debug.WriteLine($">>>> custID {Request.Query["customerID"]}");
                customer.ContactName = Request.Query["customerName"];
                System.Diagnostics.Debug.WriteLine($">>>> name {Request.Query["customerName"]}");
                customer.CompanyName = Request.Query["companyName"];
                System.Diagnostics.Debug.WriteLine($">>>> company {Request.Query["companyName"]}");
                customer.City = Request.Query["city"];
                System.Diagnostics.Debug.WriteLine($">>>> city {Request.Query["city"]}");
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
                //db.Customers.Add(customer);
                //db.SaveChanges();
                return RedirectToPage("/AllCustomers");
        }
    }
}