using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lsb_asp_dotnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["message2"] = "A message";
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult RazorHelloWorld()
        {
            ViewData["message"] = "second razor page";
            ViewBag.Message = "Second Razor";
            var PassThisString = "Send some string";
            return View("RazorHelloWorld",PassThisString);
        }
        public ActionResult Message()
        {
            ViewBag.Message = "Message";

            return View();
        }
    }
}