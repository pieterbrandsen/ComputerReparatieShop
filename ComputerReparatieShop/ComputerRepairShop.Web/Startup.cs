
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

        //  Admin password:
        private string GetPass() => "Foo";
        //  Define roles:
        private string[] GetRoles() => new[] { "Manager", "Technician" };


        private async void InitRolesAndUsers()
        {
            var context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string[] storeRoles = GetRoles();
            //  Business people:
            await CreateUniqueRoles(storeRoles, roleManager);
            //  Create first Admin role and create a default admin user:
            //if (!roleManager.RoleExists("Admin"))
            //{
            //    AdminLoginProcess(userManager, roleManager);
            //}
        }


        #region Init functions

        private void AdminLoginProcess(UserManager<ApplicationUser> umanager, RoleManager<IdentityRole> rmanager)
        {
            ApplicationUser admin = CreateAdminUser(rmanager);

            // IdentityResult ValidateUser = UserManager.Create(admin, userPWD);
            if (umanager.Create(admin, GetPass()).Succeeded)
            {
                IdentityResult result = umanager.AddToRole(admin.Id, "Admin");
            }
        }

        private ApplicationUser CreateAdminUser(RoleManager<IdentityRole> manager)
        {
            manager.Create(new IdentityRole() { Name = "Admin" });
            return new ApplicationUser() { UserName = "Admin", Email = "admin@admin.com" };
        }

        private async Task CreateUniqueRoles(string[] allRoles, RoleManager<IdentityRole> manager)
        {
            IdentityResult roleResult;

            foreach (string role in allRoles)
            {
                var roleExist = await manager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await manager.CreateAsync(new IdentityRole() { Name = role });
                }
            }
        }

        #endregion


    }
}