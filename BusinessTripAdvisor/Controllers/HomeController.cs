using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessTripAdvisor.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CitiesCRUD()
        {
            return View();
        }

        public ActionResult LifeInDifferentCountries()
        {
            return View();
        }

        public ActionResult Accommodations()
        {
            return View();
        }

        public ActionResult Transportation()
        {
            return View();
        }

        public ActionResult Feedbacks()
        {
            return View();
        }
    }
}