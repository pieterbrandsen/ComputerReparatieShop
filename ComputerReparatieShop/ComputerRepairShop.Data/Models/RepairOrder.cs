using ComputerRepairShop.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;
using System.Data.Metadata.Edm;

namespace ComputerRepairShop.Data.Models
{
    public class Part
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public string manufacturer { get; set; }
        public PartEnum Category { get; set; }
    }

    public class Technian : ApplicationUser
    {
        public decimal wage { get; set; }
        public byte  level { get; set; }
    }

    public class Customer : ApplicationUser
    {
    }

    public class RepairOrder
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        [Required]
        public RepairOrderStatus Status { get; set; }
        public string DescClient { get; set; }
        public string DescMechanic { get; set; }
        public string CustomerId { get; set; }
        public string TechnicanId { get; set; }
            //public Mechanic Assigned { get; set; }
    }

    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    //    [Required]
    //    public DateTime YearOfbirth { get; set; }
    //    public int age { get; set; }
    //}

/*    public class Mechanic : Person
    {
        public Mechanic()
        {
          this.RepairOrders = new HashSet<RepairOrder>();
        }

        public virtual void ICollection<RepairOrder> RepairOrders { get; set; }
    }*/


}
