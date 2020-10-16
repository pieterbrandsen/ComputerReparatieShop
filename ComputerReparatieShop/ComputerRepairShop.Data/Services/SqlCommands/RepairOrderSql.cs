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
        void Add(RepairOrder order);
        void Delete(int id);
        void Update(RepairOrder repairOrder);
        RepairOrder GetByOrderId(int Id);
        IEnumerable<RepairOrder> GetByCustomerId(string id);
        IEnumerable<RepairOrder> GetByEmployeeId(string id);
        IEnumerable<RepairOrder> GetAll();
        IEnumerable<PartModel> GetAllParts();
        PartModel GetPartById(int id);
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

        public IEnumerable<RepairOrder> GetByEmployeeId(string id)
        {
            return db.RepairOrders.Select(order => order).Where(prop => prop.TechnicanId == id);
        }

        public IEnumerable<RepairOrder> GetByCustomerId(string id)
        {
            return from r in db.RepairOrders
                   where r.CustomerId == id
                   select r;
        }

        public RepairOrder GetByOrderId(int id)
        {
            return db.RepairOrders.FirstOrDefault(r => r.Id == id);
        }

        public void Update(RepairOrder repairOrder)
        {
            /*var r = Get(repairOrder.Id);
            db.SaveChanges();*/
            var entry = db.Entry(repairOrder);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            return from r in db.RepairOrders
                   orderby r.StartDate
                   select r;
        }

        public PartModel GetPartById(int id)
        {
            PartModel part = db.Parts.FirstOrDefault(r => r.Id == id);
            return db.Parts.FirstOrDefault(r => r.Id == id);
        }
        public IEnumerable<PartModel> GetAllParts()
        {
            return from p in db.Parts
                   orderby p.ProductName
                   select p;
        }
    }
}
