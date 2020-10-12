using ComputerRepairShop.ClassLibrary.Helpers;
using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Web.ViewModels
{
    public class RepairOrderViewModel
    {
        public IDictionary<RepairOrderStatus, int> StatusCount { get; private set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }

        public RepairOrderViewModel(IEnumerable<RepairOrder> userIdOrder)
        {
            RepairOrders = userIdOrder;
            StatusCount = new Dictionary<RepairOrderStatus, int>();
            foreach (var statData in RepairOrders.Select(v => v.Status).GroupBy(sType => sType).Select(status => (name: status.Key, count: status.Count())))
            {
                if (StatusCount.ContainsKey(statData.name))
                    StatusCount[statData.name] += statData.count;
                else if (Enum.IsDefined(typeof(RepairOrderStatus), statData.name))
                    StatusCount.Add(statData.name, statData.count);
            }
        }
    }
}