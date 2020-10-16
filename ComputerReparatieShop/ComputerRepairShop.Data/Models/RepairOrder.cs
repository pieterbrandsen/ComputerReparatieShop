using ComputerRepairShop.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Metadata.Edm;

namespace ComputerRepairShop.Data.Models
{
    public class RepairOrder
    {
        public RepairOrder()
        {
            this.Parts = new HashSet<Part>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RepairOrderStatus Status { get; set; }
        public int HourSpent { get; set; }
        public string DescCustomer { get; set; }
        public string DescTechnican { get; set; }
        public string CustomerId { get; set; }
        public string TechnicanId { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
