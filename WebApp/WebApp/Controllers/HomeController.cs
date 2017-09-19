using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Utils;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ContosoAdsEntities db = new ContosoAdsEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Get all 
            ViewBag.Message = "Your application description page.";
            SqlUtils sqlUtils = new SqlUtils();
            IList<Category> categories = sqlUtils.FindCategories();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}