using ComputerRepairShop.Data.Services.ISqlCommands;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Models
{
    public class Customer : ApplicationUser
    {
        public Customer()
        {
            this.RepairOrders = new HashSet<RepairOrder>();
        }

        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
