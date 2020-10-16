using ComputerRepairShop.ClassLibrary.Helpers;
using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRepairShop.Web.ViewModels
{
    public class DashboardPostViewModel : RepairOrderPostViewModel
    {
        public IDictionary<RepairOrderStatus, int> OpenOrders { get; private set; }
        /*        public IEnumerable<Customer> RetrievedCustomers { get; set; }
                public IEnumerable<RepairOrder> RetrievedOrders { get; set; }*/

        public DashboardPostViewModel(IEnumerable<Customer> retrievedCustomers, IEnumerable<RepairOrder> retrievedOrders, IEnumerable<Data.Models.Technician> employees)
            : base(retrievedOrders)
        {
/*            this.RetrievedCustomers = retrievedCustomers;
            this.RetrievedOrders = retrievedOrders;*/

            OpenOrders = new Dictionary<RepairOrderStatus, int>();
            var fetchOpenOrders = retrievedOrders.Select(v => v)
                                                .Where(astat => astat.Status != RepairOrderStatus.Done)
                                                .GroupBy(order => order.Status)
                                                .Select(rstat => (name: rstat.Key, count:rstat.Count()));
            
            foreach(var stat in fetchOpenOrders)
            {
                OpenOrders.Add(stat.name, stat.count);
            }
/*            var e = retrievedOrders.Select( o => o.TechnicanId)
            var a = employees.Except()*/
        }
    }


    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            //this.RepairOrders = new HashSet<RepairOrder>();
        }

        public int Id { get; set; }
        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
        public string FullName { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        public int YearOfbirth { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<PartModel> Parts { get; set; }
    }

    public class TechnicianViewModel
    {
        public TechnicianViewModel()
        {
            //this.RepairOrders = new HashSet<RepairOrder>();
        }

        public int Id { get; set; }
        public virtual ICollection<RepairOrder> RepairOrders { get; set; }
        public string FullName { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        public int YearOfbirth { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<RepairOrder> Parts { get; set; }
    }

}