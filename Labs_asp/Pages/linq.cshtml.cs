using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Labs_asp.Models;
namespace Labs_asp.Pages
{
    public class linqModel : PageModel
    {
        public List<Custom> customers = new List<Custom>();
        public void OnGet()
        {
            using (var db = new Northwind())
            {
                customers = (from c in db.Customers
                             select new Custom
                             {
                                 Name = c.ContactName,
                                 City = c.City,
                             }).ToList();
            }
        }
    }

    public class Custom
    {
        public string Name { get; set; }
        public string City { get; set; }
    }
}