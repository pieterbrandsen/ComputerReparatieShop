using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairShop.Data.DAL
{
    class SqlComputerRepairShop : IMockDB
    {
        // TODO:
        // Replace dynamic with dbContext type
        private readonly dynamic db;

        //public SqlComputerRepairShop(<DbContext> db)
        //{
        //    this.db = db;
        // }

        public void Add(RepairOrder order)
        {
            db.repairOrders.Add(order);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderToDelete = db.repairOrders.Find(id);
        }

        public RepairOrder Get(int Id)
        {
            throw new NotImplementedException();
//            return db.repairOrders.FirstOrDefault();
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            throw new NotImplementedException();
           // return from r in db.repairOrders
           //        orderby r.Name
           //        select r;
        }
    }
}
