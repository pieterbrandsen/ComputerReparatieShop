using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerRepairShop.Classes.Helpers
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
