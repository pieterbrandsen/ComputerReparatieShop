using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services.ISqlCommands;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services.ISqlCommands
{
    public interface IRepairOrderSql
    {
        IEnumerable<RepairOrder> GetAll();
        void Add(RepairOrder order);
        RepairOrder Get(int Id);
        void Delete(int id);
        void Update(RepairOrder repairOrder);
        IEnumerable<RepairOrder> GetByRole(string id);
    }
}
namespace ComputerRepairShop.Data.Services.SqlCommands
{
    public class RepairOrderSql : IRepairOrderSql
    {
        private readonly ApplicationDbContext db;
        public RepairOrderSql(ApplicationDbContext db)
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

        public IEnumerable<RepairOrder> GetByRole(string id)
        {
            return from r in db.RepairOrders
                   where r.CustomerId == id
                   select r;
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
