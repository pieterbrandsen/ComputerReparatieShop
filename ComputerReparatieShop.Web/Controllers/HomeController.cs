using ComputerRepairShop.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ReparatieShop.Web.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD:ComputerReparatieShop/ComputerReparatieShop.Web/Controllers/HomeController.cs

=======
        private readonly IReparatieShopData db;

        public HomeController(IReparatieShopData db)
        {
            this.db = db;
        }
>>>>>>> 692eb3a2a11563bc44a11433decd57f8ff6a5edd:ComputerReperatieShop/Controllers/HomeController.cs
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
    }
}