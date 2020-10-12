using System.ComponentModel.DataAnnotations;

namespace ComputerRepairShop.ClassLibrary.Helpers
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
