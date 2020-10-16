using ComputerRepairShop.Data.Services.ISqlCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Web.ViewModels
{
    public class DashboardViewModelBuilder
    {
        private IRepairOrderSql RepairOrders;

        public DashboardViewModelBuilder(IRepairOrderSql repairOrders)
        {
            this.RepairOrders = repairOrders;
        }

    }

    public class DashboardViewModel
    {
        public DashboardViewModel(RepairOrderPostViewModel repairs)
        {

        }
    }
}