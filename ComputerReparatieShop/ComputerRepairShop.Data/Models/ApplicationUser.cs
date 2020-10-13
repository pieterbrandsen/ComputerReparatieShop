using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ComputerRepairShop.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string HomeTown { get; set; }
        public int Age { get; set; }
        public int YearOfbirth { get; set; }
        public DateTime RegisterDate { get; set; }

        public class UserDbContext : IdentityDbContext<ApplicationUser>
        {
            public UserDbContext() : base("DefaultConnection")
            {

            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<IdentityUser>().ToTable("Users");
                modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}