using Centric_Project_rc744716.DAL;
using Centric_Project_rc744716.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Centric_Project_rc744716.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "This is a way for staff to recognize each other for displaying our values.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Centric Contact Information.";

            return View();
        }
        
    

    }
}