using ReparatieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReparatieShop.Web.Models
{
    public class RepairOrderViewModel
    {
        public IDictionary<RepairOrderStatus, int> statusCount { get; set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
    }
}