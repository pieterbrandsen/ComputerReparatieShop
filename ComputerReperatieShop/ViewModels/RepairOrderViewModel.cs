using ComputerRepairShop.Data.DAL;
using ComputerRepairShop.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using ComputerRepairShop.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ComputerRepairShop.ViewModels
{
    public class RepairOrderViewModel
    {
        public IDictionary<RepairOrderStatus, int> statusCount { get; set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
    }
}