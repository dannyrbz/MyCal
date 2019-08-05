using FIT5032_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_WebApplication.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LiveChat()
        {
            return View();
        }

        public ActionResult Calculator()
        {
            return View();
        }

        // Calculates recommended intake and returns it as result.
        public ActionResult Index(CalculationModel cm)
        {

            if (ModelState.IsValid)
            {
                if (cm.Gender == "Male")
                {
                    cm.Result = 10 * cm.Weight + 6.25 * cm.Height - 5 * cm.Age + 5;
                }
                else
                {
                    cm.Result = 10 * cm.Weight + 6.25 * cm.Height - 5 * cm.Age - 161;
                }
            }

            if (cm.Age <= 0)
            {
                cm.ResultAdd1000 = cm.Result + 1000;
                cm.ResultAdd500 = cm.Result + 800;
                cm.ResultMinus1000 = cm.Result + 600;
                cm.ResultMinus500 = cm.Result + 500;
                cm.Result = cm.Result + 700;     
            }
            else
            {
                cm.ResultAdd1000 = cm.Result + 1000;
                cm.ResultAdd500 = cm.Result + 500;
                cm.ResultMinus1000 = cm.Result - 1000;
                cm.ResultMinus500 = cm.Result - 500;
            }
            return View(cm);
        }
    }
}