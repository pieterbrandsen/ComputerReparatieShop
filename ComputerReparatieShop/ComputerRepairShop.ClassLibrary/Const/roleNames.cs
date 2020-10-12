using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ComputerRepairShop.ClassLibrary.Const
{
    public static class RoleNames
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";
        public const string Technician = "Technician";
    }

    public class RoleRepo
    {
    }
    /*    public enum RoleNames
        {
            Admin,
            Customer,
            Technician

        }*/

    /*    public static class RoleNames
        {
            static string[] DefinedRoles = new string[] { "Admin", "Customer", "Technician" };
        }*/
}
