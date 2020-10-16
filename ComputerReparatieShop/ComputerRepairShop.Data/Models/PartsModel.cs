using ComputerRepairShop.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Models
{
    public class Part
    {
        public Part()
        {
            this.RepairOrders = new HashSet<RepairOrder>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Nickname { get; set; }
        public short AmountAvaiable { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public PartsCategory Category { get; set; }
        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
    }
}
