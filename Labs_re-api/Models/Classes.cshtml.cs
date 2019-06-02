using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Labs_ReDoASP.Models;
using Microsoft.EntityFrameworkCore;
namespace Labs_ReDoASP.Models
{
    public class ClassesModel : PageModel
    {
        public List<String> name = new List<string>();
        public List<String> company = new List<string>();
        public void OnGet()
        {
            using (var db = new Northwind())
            {
                foreach (Customer c in db.Customers)
                {
                    name.Add(c.ContactName);
                    company.Add(c.CompanyName);
                }
            }
        }
    }
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }



    }





    public class Northwind : DbContext
    {
        public DbSet<Customer>
    Customers
        { get; set; }


        public Northwind() { }

        public Northwind(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}