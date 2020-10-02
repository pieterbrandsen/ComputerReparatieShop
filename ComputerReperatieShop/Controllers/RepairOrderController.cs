using ComputerRepairShop.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRepairShop.Web.Controllers
{
    public class RepairOrderController : Controller
    {
        IMockDB db;

        public RepairOrderController()
        {
            db = new MockDB();
        }

        // GET: RepairOrder
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        // GET: RepairOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepairOrder/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairOrder/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepairOrder/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepairOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepairOrder/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepairOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
