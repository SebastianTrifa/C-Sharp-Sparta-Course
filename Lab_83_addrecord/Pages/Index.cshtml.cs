using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab_83_addrecord.Models;

namespace Lab_83_addrecord.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Lab_83_addrecord.Models.Northwind _context;

        public IndexModel(Lab_83_addrecord.Models.Northwind context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
