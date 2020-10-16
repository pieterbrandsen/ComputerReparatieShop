namespace ComputerRepairShop.Data.Migrations
{
    using ComputerRepairShop.ClassLibrary.Helpers;
    using ComputerRepairShop.Data.Models;
    using ComputerRepairShop.Data.Services;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ComputerRepairShop.Data.Services.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Parts.Count() < 1)
            {
                IList<PartModel> parts = new List<PartModel>();

                parts.Add(new PartModel()
                {
                    Manufacturer = "Jntel",
                    ProductName = "10900Z",
                    Nickname = "Hoog cijfer",
                    Category = PartsCategory.Cpu,
                    Price = 199.99M
                });

                parts.Add(new PartModel()
                {
                    Manufacturer = "AMC",
                    ProductName = "AMC Rozen 2",
                    Nickname = "Rozen too hard",
                    Category = PartsCategory.Gpu,
                    Price = 0M
                });
                parts.Add(new PartModel()
                {
                    Manufacturer = "Nvidio",
                    ProductName = "4080 Ti XL",
                    Nickname = "Better then 3080",
                    Category = PartsCategory.Gpu,
                    Price = 69.69M
                });
                parts.Add(new PartModel()
                {
                    Manufacturer = "Cooler case",
                    ProductName = "Cooler 3000",
                    Nickname = "Too cool",
                    Category = PartsCategory.Case,
                    Price = 19.99M
                });
                parts.Add(new PartModel()
                {
                    Manufacturer = "Mobot",
                    ProductName = "Asur mpog 3012",
                    Nickname = "No name...",
                    Category = PartsCategory.Mobo,
                    Price = 1999.99M
                });
                parts.Add(new PartModel()
                {
                    Manufacturer = "Samseng",
                    ProductName = "950 SSO",
                    Nickname = "A part",
                    Category = PartsCategory.Storage,
                    Price = 1399.99M
                });



                foreach (PartModel part in parts)
                {
                    context.Parts.Add(part);
                }
                context.SaveChanges();

            }
            base.Seed(context);
        }
    }
}
