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
            
            return View(model);
        }

        // GET: RepairOrder/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var allParts = db.GetAllParts();
            var model = RepairOrderViewModel.RepairOrderVM(db.GetByOrderId(id), new int[0], allParts);


            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Authorize]
        [ActionName("PassDownModel")]
        public ActionResult Details(int id, RepairOrderViewModel model)
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
            var allParts = db.GetAllParts();
            var model = RepairOrderViewModel.RepairOrderVM(new RepairOrder(), new int[0], allParts);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: RepairOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairOrderViewModel repairOrderViewModel, FormCollection collection)
        {
            RepairOrder repairOrder = ConvertVMToM(repairOrderViewModel);
            // TODO: Uncomment bottom redirect to go to unimplemented details views.
            repairOrder.TechnicanId = User.Identity.GetUserId();
            db.Add(repairOrder);
            //return RedirectToAction("Index");
            return RedirectToAction("Details", new { id = repairOrder.Id });
        }

        // GET: RepairOrder/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var allParts = db.GetAllParts();
            var model = RepairOrderViewModel.RepairOrderVM(db.GetByOrderId(id), new int[0], allParts);
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
            try
            {
                if (repairOrderViewModel.SelectedParts != null && repairOrderViewModel.SelectedParts.Length > 0)
                {
                    foreach (var part in repairOrderViewModel.SelectedParts)
                    {
                        repairOrder.Parts.Add(db.GetPartById(part));
                    }
                }
                if (repairOrderViewModel.Parts.Count > 0)
                {
                    foreach (var part in repairOrderViewModel.Parts)
                    {
                        repairOrder.Parts.Add(part);
                    }
                }

                db.Update(repairOrder);
                return View(repairOrderViewModel);
                //  return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepairOrder/Delete/5
        public ActionResult Delete(int id)
        {
            var allParts = db.GetAllParts();
            var model = RepairOrderViewModel.RepairOrderVM(db.GetByOrderId(id), new int[0], allParts);
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
            RepairOrder repairOrder = new RepairOrder
            {
                Id = repairOrderViewModel.Id,
                Name = repairOrderViewModel.Name,
                StartDate = repairOrderViewModel.StartDate,
                EndDate = repairOrderViewModel.StartDate,
                Status = repairOrderViewModel.Status,
                DescCustomer = repairOrderViewModel.DescCustomer,
                DescTechnican = repairOrderViewModel.DescTechnican,
                Parts = repairOrderViewModel.Parts
            };
            //repairOrder.Id = repairOrderViewModel.Id;
            //repairOrder.Name = repairOrderViewModel.Name;
            //repairOrder.StartDate = repairOrderViewModel.StartDate;
            //repairOrder.EndDate = repairOrderViewModel.EndDate;
            //repairOrder.Status = repairOrderViewModel.Status;
            //repairOrder.DescCustomer = repairOrderViewModel.DescCustomer;
            //repairOrder.DescTechnican = repairOrderViewModel.DescTechnican;

             return repairOrder;
        }

        //private static RepairOrderViewModel ConvertMToVM(RepairOrder repairOrder)
        //{
        //    RepairOrder repairOrder = new RepairOrder();

        //}

        #endregion
    }
}
