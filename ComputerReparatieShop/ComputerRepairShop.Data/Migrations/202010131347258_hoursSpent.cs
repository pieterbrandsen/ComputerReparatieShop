namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoursSpent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrders", "HourSpent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RepairOrders", "HourSpent");
        }
    }
}
