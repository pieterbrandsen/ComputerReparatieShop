using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairShop.Data.DAL
{
    class SqlComputerRepairShop : IMockDB
    {
        //private readonly <DbContext> SqlComputerRepairShop;

        //public SqlComputerRepairShop(<DbContext> db)
        //{
        //    this.SqlComputerRepairShop = db;
        // }

        public void Add(RepairOrder order)
        {
            throw new NotImplementedException();
        }

        public RepairOrder Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
