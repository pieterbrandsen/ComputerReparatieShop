using ComputerReperatieShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerReperatieShop.Data.DAL
{
    public interface IMockDB
    {
        IEnumerable<RepairOrder> GetAll();
        void Add(RepairOrder order);
        RepairOrder Get(int Id);

    }
}
