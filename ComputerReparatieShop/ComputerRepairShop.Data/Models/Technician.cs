using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ComputerRepairShop.Data.Models
{
    public class Technician : ApplicationUser
    {
        public Technician()
        {
            this.RepairOrders = new HashSet<RepairOrder>();
        }

        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
        public decimal Wage { get; set; }
        public int Level { get; set; }
    }
}
