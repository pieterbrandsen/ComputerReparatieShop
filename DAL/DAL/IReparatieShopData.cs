using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerRepairShop.Data.DAL
{
    public interface IReparatieShopData
    {
        IEnumerable<RepairOrder> GetAll();
        void Add(RepairOrder order);
        RepairOrder Get(int Id);
        void Delete(int id);
        void Update(RepairOrder repairOrder);
    }
}
