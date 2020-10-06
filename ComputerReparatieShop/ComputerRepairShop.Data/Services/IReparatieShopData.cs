using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Data.Services
{
    public interface IComputerRepairShopData
    {
        IEnumerable<RepairOrder> GetAll();
        void Add(RepairOrder order);
        RepairOrder Get(int Id);
        void Delete(int id);
        void Update(RepairOrder repairOrder);
    }
}
