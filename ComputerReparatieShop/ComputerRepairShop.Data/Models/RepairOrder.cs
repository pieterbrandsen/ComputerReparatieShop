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
        public Part()
        {
            this.RepairOrders = new HashSet<RepairOrder>();
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Nickname { get; set; }
        public short AmountAvaiable { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public PartsCategory Category { get; set; }
        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
    }


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
        public string DescClient { get; set; }
        public string DescMechanic { get; set; }
        public string CustomerId { get; set; }
        public string TechnicanId { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
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
