using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Labs_90_view_practice.Models;

namespace Labs_90_view_practice.Controllers
{
    public class HomeController : Controller
    {
        public Nonstatic inst = new Nonstatic();
        public IActionResult Index()
        {
            inst.list.Add("first");
            inst.list.Add("second");
            Practice.list.Add("first");
            Practice.list.Add("second");
            ViewBag.ListView = Practice.list;
            return View("Contact",inst);
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
