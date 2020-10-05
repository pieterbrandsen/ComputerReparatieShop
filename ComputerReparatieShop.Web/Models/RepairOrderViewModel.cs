using ReparatieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD:ComputerReparatieShop/ComputerReparatieShop.Web/Models/RepairOrderViewModel.cs
=======
using System.Security.Cryptography.X509Certificates;
using ComputerRepairShop.Data.Models;
using System.ComponentModel.DataAnnotations;
>>>>>>> 692eb3a2a11563bc44a11433decd57f8ff6a5edd:ComputerReperatieShop/ViewModels/RepairOrderViewModel.cs

namespace ReparatieShop.Web.Models
{
    public class RepairOrderViewModel
    {
        public IDictionary<RepairOrderStatus, int> statusCount { get; set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }
    }
}