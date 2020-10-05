using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ComputerRepairShop.Data.Models;

namespace ComputerRepairShop.Data.DAL
{
    class ReparatieShopDbContext : DbContext
    {
        public DbSet<RepairOrder> RepairOrders { get; set; }

    }
}
