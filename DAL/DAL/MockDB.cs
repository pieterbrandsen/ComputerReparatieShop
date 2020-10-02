using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerReperatieShop.Data.Models;

namespace ComputerReperatieShop.Data.DAL
{
    class MockDB
    {
        List<RepairOrder> repairOrders;

        public MockDB()
        {
            repairOrders = new List<RepairOrder>()
            {
                new RepairOrder {Id = 0, Name = "Name0", Description = "Description0", Status = Status.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 1, Name = "Name1", Description = "Description1", Status = Status.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 2, Name = "Name2", Description = "Description2", Status = Status.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 3, Name = "Name3", Description = "Description3", Status = Status.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 4, Name = "Name4", Description = "Description4", Status = Status.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
            };
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            return repairOrders.OrderBy(r => r.Name);
        }
    }
}
