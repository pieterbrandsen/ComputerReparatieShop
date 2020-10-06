using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReparatieShop.Models
{
    public enum RepairOrderStatus
    {
        Pending,
        Underway,
        [Display(Name = "Waiting for parts")]
        WaitingForParts,
        Done
    }
}
