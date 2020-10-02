using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairShop.Data.DAL
{
    public interface IMockDB
    {
        IEnumerable<RepairOrder> GetAll();
    }
}
