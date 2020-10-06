using ReparatieShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReparatieShop.Services
{
    public class ReparatieShopDbContext : DbContext
    {
        public DbSet<RepairOrder> RepairOrders { get; set; }
    }
}
