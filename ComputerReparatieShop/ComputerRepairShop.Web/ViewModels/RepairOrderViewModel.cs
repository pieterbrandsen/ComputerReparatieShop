using ComputerRepairShop.Helpers;
using ComputerRepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Web.ViewModels
{
    public class RepairOrderViewModel
    {
        public IDictionary<RepairOrderStatus, int> statusCount { get; set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
    }
}