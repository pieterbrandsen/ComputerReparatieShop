
using ComputerRepairShop.ClassLibrary.Const;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

[assembly: OwinStartupAttribute(typeof(ComputerRepairShop.Web.Startup))]
namespace ComputerRepairShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitRolesAndUsers();
        }

        //  Define roles:
        private string[] GetRoles() => new[] { RoleNames.Admin, RoleNames.Customer, RoleNames.Technician };


        private async void InitRolesAndUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //  Business people:
            await CreateUniqueRoles(GetRoles(), roleManager);
            await CheckForAdmin(userManager, roleManager);
        }


        #region Init functions

        private async Task CheckForAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var findAdmin = userManager.FindByName(RoleNames.Admin);
            if (findAdmin == null)
            {
                // Create first Admin role as default user.
                ApplicationUser admin = CreateAdminUser(roleManager);

                // IdentityResult ValidateUser = UserManager.Create(admin, userPWD);
                if (await userManager.CreateAsync(admin) == IdentityResult.Success)
                {
                    await userManager.AddToRoleAsync(admin.Id, RoleNames.Admin);
                }
            }
        }

        private ApplicationUser CreateAdminUser(RoleManager<IdentityRole> roleManager)
        {
            roleManager.Create(new IdentityRole() { Name = RoleNames.Admin });
            return new ApplicationUser() { UserName = RoleNames.Admin, Email = "admin@admin.com", PasswordHash = "AEiskmtYlxYlSi1XPYIrF+NckSb2z4sBs+LiEj7mEndCOamyPZ+iPaufbpOsELwkpg==" };
        }

        private async Task CreateUniqueRoles(string[] allRoles, RoleManager<IdentityRole> roleManager)
        {
            foreach (string role in allRoles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = role });
                }
            }
        }

        #endregion


    }
}