using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs_asp.Models;

namespace Labs_asp.Pages
{
    public class OrderByModel : PageModel
    {
        public List<Customer> newlist = new List<Customer>();
        public void OnGet()
        {
            using (var db = new Northwind())
            {
                var customer = from c in db.Customers
                               orderby c.City
                               select c;
                newlist = customer.ToList();
            }
        }
    }
}