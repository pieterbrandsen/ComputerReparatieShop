using ComputerRepairShop.ClassLibrary.Const;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services;
using ComputerRepairShop.Data.Services.ISqlCommands;
using ComputerRepairShop.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepairOrderSql db;
        private ICustomerSql cDb;
        private ITechnicanSql tDb;
        
        public HomeController(IRepairOrderSql db, ICustomerSql cDb, ITechnicanSql tDb)
        {
            // TODO: Change to method injection for less calls etc..
            this.db = db;
            this.cDb = cDb;
            this.tDb = tDb;
        }
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Name = "Not logged in.";
            }
            else
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";
                if (User.IsInRole(RoleNames.Admin))
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
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
        [Authorize]
        public ActionResult DashBoard()
         {
            var selectedOrders = User.IsInRole(RoleNames.Customer) ?
                                 db.GetByCustomerId(User.Identity.GetUserId()) :
                                 User.IsInRole(RoleNames.Technician) ?
                                 db.GetByEmployeeId(User.Identity.GetUserId()) :
                                 db.GetAll();

            var customers = cDb.GetAll();
            var employees = tDb.GetAll();

            var model = new DashboardPostViewModel(customers, selectedOrders, employees);

            return View(model);
        }
    }
}