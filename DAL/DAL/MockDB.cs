using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.DAL
{
    class MockDB
    {
        readonly List<RepairOrder> repairOrders;

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
    }
}
