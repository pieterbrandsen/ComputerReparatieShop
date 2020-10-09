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
    public class CustomerController : Controller
    {
        private ICustomerSql db;

        public CustomerController(ICustomerSql db)
        {
            this.db = db;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.GetAll();

            return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer, FormCollection collection)
        {
            db.Add(customer);
            return RedirectToAction("Index");
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,HomeTown,Age,YearOfbirth,OpenOrders,ClosedOrders,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(customer);
                    // TODO: Uncomment "Details" redirect when implemented
                    // return RedirectToAction("Details", new { id = repairOrder.Id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
