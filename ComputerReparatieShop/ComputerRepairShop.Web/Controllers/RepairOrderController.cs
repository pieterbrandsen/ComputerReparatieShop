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
using ComputerRepairShop.ClassLibrary.Const;
using Microsoft.AspNet.Identity;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using Microsoft.Ajax.Utilities;
using System.Web.Security;

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
            var selectedOrders = User.IsInRole(RoleNames.Customer) ?
                                 db.GetByCustomerId(User.Identity.GetUserId()) :
                                 db.GetAll();

            var model = new RepairOrderPostViewModel(selectedOrders);
            /*          
           *Refactored and moved to view model:

                        if (User.IsInRole(RoleNames.Technician)) 
                            selectedOrders = db.GetAll();
                        else if ( User.IsInRole(RoleNames.Admin))
                            selectedOrders = db.GetAll();
                        else
                            selectedOrders = db.GetByCustomerId(User.Identity.GetUserId());

            var model = new RepairOrderPostViewModel(selectedOrders);
                    
            IEnumerable<RepairOrder> repairOrders = db.GetByRole(User.Identity.GetUserId());
            IDictionary<RepairOrderStatus, int> statusCount = new Dictionary<RepairOrderStatus, int>();

            statusCount.Add(RepairOrderStatus.Done, 0);
            statusCount.Add(RepairOrderStatus.Pending, 0);
            statusCount.Add(RepairOrderStatus.Underway, 0);
            statusCount.Add(RepairOrderStatus.WaitingForParts, 0);

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
            model.RepairOrders = repairOrders;
            model.StatusCount = statusCount;
            */
            return View(model);
        }

        // GET: RepairOrder/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var model = db.GetByOrderId(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize]
        [ActionName("PassDownModel")]
        public ActionResult Details(int id, RepairOrder model)
        {
            //var model = db.GetByOrderId(id);
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
            var model = RepairOrderViewModel.RepairOrderVM(db.GetByOrderId(id));
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: RepairOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepairOrderViewModel repairOrderViewModel, FormCollection collection)
        {
            var repairOrder = ConvertVMToM(repairOrderViewModel);
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(repairOrder);
                    return RedirectToAction("Details", new { id = repairOrder.Id });
                    //  return RedirectToAction("Index");
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
            var model = db.GetByOrderId(id);
            return (model is object) ? View(model) : View("Not found");
        
            /*if (db.GetByOrderId(id) is object)
                return View(model);
            else
                return View("Not found"); */
        }

        // POST: RepairOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        #region Helpers

        private static RepairOrder ConvertVMToM(RepairOrderViewModel repairOrderViewModel)
        {
            RepairOrder repairOrder = new RepairOrder();

            repairOrder.Id = repairOrderViewModel.Id;
            repairOrder.Name = repairOrderViewModel.Name;
            repairOrder.StartDate = repairOrderViewModel.StartDate;
            repairOrder.EndDate = repairOrderViewModel.EndDate;
            repairOrder.Status = repairOrderViewModel.Status;
            repairOrder.DescCustomer = repairOrderViewModel.DescCustomer;
            repairOrder.DescTechnican = repairOrderViewModel.DescTechnican;

            return repairOrder;
        }

        //private static RepairOrderViewModel ConvertMToVM(RepairOrder repairOrder)
        //{
        //    RepairOrder repairOrder = new RepairOrder();

        //}

        #endregion
    }
}
