using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Homework_106_webpage.Models;

namespace Homework_108_webpage.Pages
{
    public class CustomersModel : PageModel
    {
        public List<Customer> customers = new List<Customer>();
        public void OnGet()
        {
            string city = Request.Query["City"];
            using (var db = new Northwind())
            {
                customers = (from c in db.Customers
                             where c.City == city
                             select c).ToList();
            }
        }
    }
}