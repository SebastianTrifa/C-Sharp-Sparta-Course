using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homework_112_MVCEntity.Models;

namespace Homework_112_MVCEntity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<string> list = new List<string>();
            using (var db = new Northwind())
            {
                List<Customer> cust = new List<Customer>();
                cust = db.Customers.ToList();
                foreach(var l in cust)
                {
                    list.Add(l.ContactName);
                }
            }
            ViewBag.CustList = list;
            return View("Contact", list);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
