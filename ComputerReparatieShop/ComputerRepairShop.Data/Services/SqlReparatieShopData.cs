using ComputerRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services
{
    public class SqlComputerRepairShopData : IComputerRepairShopData
    {
        private readonly ComputerRepairShopDbContext db;

        public SqlComputerRepairShopData(ComputerRepairShopDbContext db)
        {
            this.db = db;
        }

        public void Add(RepairOrder order)
        {
            db.RepairOrders.Add(order);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var repairOrder = db.RepairOrders.Find(id);
            db.RepairOrders.Remove(repairOrder);
            db.SaveChanges();
        }

        public RepairOrder Get(int id)
        {
            return db.RepairOrders.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            return from r in db.RepairOrders
                   orderby r.StartDate
                   select r;
        }

        public void Update(RepairOrder repairOrder)
        {
            /*var r = Get(repairOrder.Id);
            db.SaveChanges();*/
            var entry = db.Entry(repairOrder);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
