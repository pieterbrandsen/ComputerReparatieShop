using ReparatieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReparatieShop.Services
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
