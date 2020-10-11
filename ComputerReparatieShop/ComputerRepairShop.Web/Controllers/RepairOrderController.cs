using ComputerRepairShop.Web.ViewModels;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerRepairShop.Data.Services.SqlCommands;
using ComputerRepairShop.Data.Services.ISqlCommands;
using Microsoft.AspNet.Identity;
using System.ComponentModel;

namespace ComputerRepairShop.Web.Controllers
{
    public class RepairOrderController : Controller
    {
        private IRepairOrderSql db;

        public RepairOrderController(IRepairOrderSql db)
        {
            this.db = db;
        }

        // GET: RepairOrder
        [Authorize]
        public ActionResult Index(string id)
        {
            IEnumerable<RepairOrder> repairOrders = db.GetByRole(User.Identity.GetUserId());
            IDictionary<RepairOrderStatus, int> statusCount = new Dictionary<RepairOrderStatus, int>();

            foreach (RepairOrderStatus stat in Enum.GetValues(typeof(RepairOrderStatus)))
            {
                    statusCount.Add(stat, 0);
            }
            
            RepairOrder switch
            {
                RepairOrder c
            }
            var t = repairOrders.GroupBy(order => statusCount[order.Status]++);
            //repairOrders.GroupBy(order => statusCount[order.Status]++);
            foreach (var repairOrder in repairOrders)
            {
                switch (repairOrder.Status)
                {
                    case RepairOrderStatus.Done:
                        statusCount[RepairOrderStatus.Done]++;
                        break;
                    case RepairOrderStatus.Pending:
                        statusCount[RepairOrderStatus.Pending]++;
                        break;
                    case RepairOrderStatus.Underway:
                        statusCount[RepairOrderStatus.Underway]++;
                        break;
                    case RepairOrderStatus.WaitingForParts:
                        statusCount[RepairOrderStatus.WaitingForParts]++;
                        break;
                    default:
                        break;
                }
            }
            var model = new RepairOrderViewModel();

            model.RepairOrders = repairOrders;
            model.statusCount = statusCount;
            return View(model);
        }

        // GET: RepairOrder/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: RepairOrder/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairOrder repairOrder, FormCollection collection)
        {
            // TODO: Uncomment bottom redirect to go to unimplemented details views.
            repairOrder.CustomerId = User.Identity.GetUserId();
            db.Add(repairOrder);
            //return RedirectToAction("Index");
            return RedirectToAction("Details", new { id = repairOrder.Id });
        }

        // GET: RepairOrder/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: RepairOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepairOrder repairOrder, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(repairOrder);
                    // TODO: Uncomment "Details" redirect when implemented
                    // return RedirectToAction("Details", new { id = repairOrder.Id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(repairOrder);
        }

        // GET: RepairOrder/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // POST: RepairOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
