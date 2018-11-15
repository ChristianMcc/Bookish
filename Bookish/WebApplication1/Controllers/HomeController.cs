using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.DataAccess;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About the fake library";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please don't contact me";

            return View();
        }

        
    }
}