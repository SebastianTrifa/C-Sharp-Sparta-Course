using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GroupProject_WebPage.Models;

namespace GroupProject_WebPage.NewFolder
{
    public class IndexModel : PageModel
    {
        private readonly GroupProject_WebPage.Models.SpartaModel _context;

        public IndexModel(GroupProject_WebPage.Models.SpartaModel context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
