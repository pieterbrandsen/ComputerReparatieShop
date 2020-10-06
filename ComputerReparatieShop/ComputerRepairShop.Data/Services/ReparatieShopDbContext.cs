using ComputerRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Services
{
    public class ComputerRepairShopDbContext : DbContext
    {
        public DbSet<RepairOrder> RepairOrders { get; set; }
    }
}
