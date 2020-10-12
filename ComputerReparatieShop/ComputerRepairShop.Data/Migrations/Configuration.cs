namespace ComputerRepairShop.Data.Migrations
{
    using ComputerRepairShop.ClassLibrary.Helpers;
    using ComputerRepairShop.Data.Models;
    using ComputerRepairShop.Data.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Graph;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerRepairShop.Data.Services.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ComputerRepairShop.Data.Services.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
