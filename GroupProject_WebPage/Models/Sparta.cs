using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GroupProject_WebPage.Models
{
    public class SpartaModel : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Cohorts> Cohorts { get; set; }
        public DbSet<Specialisations> Specialisations { get; set; }
        public DbSet<Roles> Roles { get; set; }


        public SpartaModel() { }

        public SpartaModel(DbContextOptions options) : base(options) { }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
