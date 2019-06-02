using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs_asp.Models;

namespace Labs_asp.Pages
{
    public class GroupByModel : PageModel
    {
        public List<Output> groupcust;
        public void OnGet()
        {
            using (var db = new Northwind())
            {
                groupcust = (from c in db.Customers
                             group c by c.City into g
                             select new Output { City = g.Key, Count = g.Count() }).ToList();
            }
        }
    }
    public class Output
    {
        public string City { get; set; }
        public int Count { get; set; }
    }
}