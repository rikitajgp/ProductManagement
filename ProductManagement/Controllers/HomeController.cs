using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Filters;

namespace ProductManagement.Controllers
{
    public class HomeController : Controller
    {
        //Adding comment in HomeControllerfgfgfggg
        [CustomFilter]
        public ActionResult Index()
        {
            

            return View();
        }

        public ActionResult About(string strValue)
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.RedirectMessage = strValue;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}