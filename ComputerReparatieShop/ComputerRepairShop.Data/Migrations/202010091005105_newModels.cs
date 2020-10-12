namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrders", "DescClient", c => c.String());
            AddColumn("dbo.RepairOrders", "DescMechanic", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.AspNetUsers", "HomeTown", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "YearOfbirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "OpenOrders", c => c.String());
            AddColumn("dbo.AspNetUsers", "ClosedOrders", c => c.String());
            AddColumn("dbo.AspNetUsers", "Wage", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Level", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.RepairOrders", "Description_Client");
            DropColumn("dbo.RepairOrders", "Description_Mechanic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairOrders", "Description_Mechanic", c => c.String());
            AddColumn("dbo.RepairOrders", "Description_Client", c => c.String());
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Level");
            DropColumn("dbo.AspNetUsers", "Wage");
            DropColumn("dbo.AspNetUsers", "ClosedOrders");
            DropColumn("dbo.AspNetUsers", "OpenOrders");
            DropColumn("dbo.AspNetUsers", "YearOfbirth");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "HomeTown");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.RepairOrders", "DescMechanic");
            DropColumn("dbo.RepairOrders", "DescClient");
        }
    }
}
