using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab_83_addrecord.Models;

namespace Lab_83_addrecord.Pages
{
    public class NorthwindModel : PageModel
    {
        public List<Customer> customers;
        public void OnGet()
        {
            using(var db = new Northwind())
            {
                customers = db.Customers.Skip(10).Take(10).ToList();
            }
        }
    }
}