using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services;
using ComputerRepairShop.Data.Services.ISqlCommands;

namespace ComputerRepairShop.Web.Controllers
{
    public class TechnicanController : Controller
    {
        private ITechnicanSql db;

        public TechnicanController(ITechnicanSql db)
        {
            this.db = db;
        }

        // GET: Technicans
        public ActionResult Index()
        {
            var customers = db.GetAll();

            return View(customers);
        }

        // GET: Technicans/Details/5
        public ActionResult Details(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Technicans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Technicans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Technician technican, FormCollection collection)
        {
            db.Add(technican);
            return RedirectToAction("Index");
        }

        // GET: Technicans/Edit/5
        public ActionResult Edit(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Technicans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,HomeTown,Age,YearOfbirth,RegisterDate,OpenOrders,ClosedOrders,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Wage,Level")] Technician technican)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(technican);
                    // TODO: Uncomment "Details" redirect when implemented
                    // return RedirectToAction("Details", new { id = repairOrder.Id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(technican);
        }

        // GET: Technicans/Delete/5
        public ActionResult Delete(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // POST: Technicans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
