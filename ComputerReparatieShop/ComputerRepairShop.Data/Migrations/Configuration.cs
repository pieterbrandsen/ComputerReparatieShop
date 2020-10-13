namespace ComputerRepairShop.Data.Migrations
{
    using ComputerRepairShop.ClassLibrary.Helpers;
    using ComputerRepairShop.Data.Models;
    using ComputerRepairShop.Data.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Graph;
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
            ContextKey = "ComputerRepairShop.Data.Services.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Parts.Count() < 1)
            {
                IList<Part> parts = new List<Part>();

                parts.Add(new Part()
                {
                    Manufacturer = "Jntel",
                    ProductName = "10900Z",
                    Nickname = "Hoog cijfer",
                    Category = PartsCategory.Cpu,
                    Price = 199.99M
                });

                parts.Add(new Part()
                {
                    Manufacturer = "AMC",
                    ProductName = "AMC Rozen 2",
                    Nickname = "Rozen too hard",
                    Category = PartsCategory.Gpu,
                    Price = 0M
                });
                parts.Add(new Part()
                {
                    Manufacturer = "Nvidio",
                    ProductName = "4080 Ti XL",
                    Nickname = "Better then 3080",
                    Category = PartsCategory.Gpu,
                    Price = 69.69M
                });
                parts.Add(new Part()
                {
                    Manufacturer = "Cooler case",
                    ProductName = "Cooler 3000",
                    Nickname = "Too cool",
                    Category = PartsCategory.Case,
                    Price = 19.99M
                });
                parts.Add(new Part()
                {
                    Manufacturer = "Mobot",
                    ProductName = "Asur mpog 3012",
                    Nickname = "No name...",
                    Category = PartsCategory.Mobo,
                    Price = 1999.99M
                });
                parts.Add(new Part()
                {
                    Manufacturer = "Samseng",
                    ProductName = "950 SSO",
                    Nickname = "A part",
                    Category = PartsCategory.Storage,
                    Price = 1399.99M
                });



                foreach (Part part in parts)
                {
                    context.Parts.Add(part);
                }
                context.SaveChanges();

            }
                base.Seed(context);
        }
    }
}
