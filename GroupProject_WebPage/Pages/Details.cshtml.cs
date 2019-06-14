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
    public class DetailsModel : PageModel
    {
        private readonly GroupProject_WebPage.Models.SpartaModel _context = new SpartaModel();

        public DetailsModel()
        {
            //_context = context;
        }

        public Users Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Users = await _context.Users.FirstOrDefaultAsync(m => m.UserID == id);

            if (Users == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
