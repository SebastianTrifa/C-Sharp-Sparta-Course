using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab_83_addrecord.Models;
using Microsoft.Extensions.Primitives;

namespace Lab_83_addrecord.Pages
{
    public class EditCustomerModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers;
        public string ccn;
        public string ccon;
        public string cc;
        public string cid = "";
        public Customer customer = new Customer();
        public EditCustomerModel(Northwind EditContext)
        {
            db = EditContext;
        }
        public IActionResult OnGet()
        {
            customers = db.Customers.Take(10).ToList();
            System.Diagnostics.Debug.WriteLine($">>>> custID {Request.Query["customerID"]}");
            if (Request.Query["customerID"] != StringValues.Empty)
            {
                cid = Request.Query["customerID"];
                System.Diagnostics.Debug.WriteLine($">>>> if custID {cid}");
                customer = db.Customers.Where(c => c.CustomerID == cid).ToList().First();
                ccn = customer.ContactName;
                ccon = customer.CompanyName;
                cc = customer.City;
                return Page();
            }
            else if (Request.Query["ID"] != StringValues.Empty)
            {
                customer = db.Customers.Where(c => c.CustomerID == Request.Query["ID"]).ToList().First();
                customer.ContactName = Request.Query["customerName"];
                customer.CompanyName = Request.Query["companyName"];
                customer.City = Request.Query["city"];
                db.SaveChanges();
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }
    }
}