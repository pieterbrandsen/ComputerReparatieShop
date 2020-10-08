using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ComputerRepairShop.ClassLibrary.Helpers
{
    static class RoleCheck
    {
        // TODO: Implement admin check as static method.
        #region Helper methods for Actions:
/*
        public static Boolean isAdminUser(IPrincipal User)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currUser = UserManager.GetRoles(user.GetUserId());
                return currUser[0].ToString() == "Admin" ? true : false;
            }
            return false;
        }*/

        #endregion
    }
}
