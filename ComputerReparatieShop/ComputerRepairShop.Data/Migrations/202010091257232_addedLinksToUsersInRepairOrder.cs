namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLinksToUsersInRepairOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RepairOrders", "CustomerId", c => c.String());
            AddColumn("dbo.RepairOrders", "TechnicanId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairOrders", "TechnicanId");
            DropColumn("dbo.RepairOrders", "CustomerId");
            DropColumn("dbo.AspNetUsers", "RegisterDate");
        }
    }
}
