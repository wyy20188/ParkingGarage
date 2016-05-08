using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Price()
        {
            return View();
        }
        public ActionResult Status()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}