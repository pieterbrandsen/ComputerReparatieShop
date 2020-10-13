namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "OpenOrders");
            DropColumn("dbo.AspNetUsers", "ClosedOrders");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ClosedOrders", c => c.String());
            AddColumn("dbo.AspNetUsers", "OpenOrders", c => c.String());
        }
    }
}
