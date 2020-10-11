using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services
{
    public class SqlComputerRepairShopData
    {
        private readonly ApplicationDbContext db;


        // TODO: Implement get by role after enabling machanic assignment to orders.
        public IEnumerable<RepairOrder> GetByRole(string id)
        {
            return from r in db.RepairOrders
                   where r.TechnicanId == id
                   select r;
        }
    }
}
