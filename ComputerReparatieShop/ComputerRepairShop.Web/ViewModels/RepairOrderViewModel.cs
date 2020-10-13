using ComputerRepairShop.ClassLibrary.Helpers;
using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Web.ViewModels
{
    public class RepairOrderPostViewModel
    {
        public IDictionary<RepairOrderStatus, int> StatusCount { get; private set; }
        public IEnumerable<RepairOrder> RepairOrders { get; set; }

        public RepairOrderPostViewModel(IEnumerable<RepairOrder> retrievedOrders)
        {
            RepairOrders = retrievedOrders;
            StatusCount = new Dictionary<RepairOrderStatus, int>();
            foreach (var statData in RepairOrders.Select(order => order.Status).GroupBy(sType => sType).Select(status => (name: status.Key, count: status.Count())))
            {
                StatusCount.Add(statData.name, statData.count);
            }
            if (StatusCount.Count() < Enum.GetValues(typeof(RepairOrderStatus)).Length)
            {
                foreach (var status in Enum.GetValues(typeof(RepairOrderStatus)))
                {
                    if (!StatusCount.ContainsKey((RepairOrderStatus)status))
                        StatusCount.Add((RepairOrderStatus)status, 0);

                }
            }
        }
    }
    public class RepairOrderViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Opdracht naam")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Start datum")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Eind datum")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Huidige status")]
        public RepairOrderStatus Status { get; set; }

        [Required]
        [Display(Name = "Beschrijving van klant")]
        public string DescCustomer { get; set; }

        [Required]
        [Display(Name = "Beschrijving van reparateur")]
        public string DescTechnican { get; set; }

        public static RepairOrderViewModel RepairOrderVM(RepairOrder order)
        {
            RepairOrderViewModel repairOrder = new RepairOrderViewModel();
            repairOrder.Id = order.Id;
            repairOrder.Name = order.Name;
            repairOrder.StartDate = order.StartDate;
            repairOrder.EndDate = order.StartDate;
            repairOrder.Status = order.Status;
            repairOrder.DescCustomer = order.DescCustomer;
            repairOrder.DescTechnican = order.DescTechnican;

            return repairOrder;
        }

        //private RepairOrder repairOrder = new RepairOrder;

        //public int Id => repairOrder.Id;
        //[Required]
        //[Display(Name = "Opdracht naam")]
        //public string Name => repairOrder.Name;

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[Display(Name = "Start datum")]
        //public DateTime StartDate => repairOrder.StartDate;

        //[Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[Display(Name = "Eind datum")]
        //public DateTime EndDate => repairOrder.EndDate;

        //[Required]
        //[Display(Name = "Huidige status")]
        //public RepairOrderStatus Status => repairOrder.Status;

        //[Required]
        //[Display(Name = "Beschrijving van klant")]
        //public string DescCustomer => repairOrder.DescCustomer;

        //[Required]
        //[Display(Name = "Beschrijving van reparateur")]
        //public string DescTechnican => repairOrder.DescTechnican;
    }
}