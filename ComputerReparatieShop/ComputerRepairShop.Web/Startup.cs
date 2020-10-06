using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Data.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(ComputerRepairShop.Web.Startup))]
namespace ComputerRepairShop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // Create default users and Admins:
        private void CreaterolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //  In this method create first Admin role and creating a default admin user:
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Here we create a admin user:
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@admin.nl";

                string userPWD = "Foo";//"AQAAAAEAACcQAAAAEC7vUlO2YPPjCAHhbTu4VWhY4fPF/p1lJqGE2X3tMjECNIaNaku8Eqo1exLzHAkwqw==";

                var chkuser = UserManager.Create(user, userPWD);

                // Add default user to admin:
                if(chkuser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            // creating Creating Manager role     
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
    }
}
