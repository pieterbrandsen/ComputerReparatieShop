namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updat312 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrders", "DescClient", c => c.String());
            AddColumn("dbo.RepairOrders", "DescMechanic", c => c.String());
            DropColumn("dbo.RepairOrders", "DescCustomer");
            DropColumn("dbo.RepairOrders", "DescTechnican");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairOrders", "DescTechnican", c => c.String());
            AddColumn("dbo.RepairOrders", "DescCustomer", c => c.String());
            DropColumn("dbo.RepairOrders", "DescMechanic");
            DropColumn("dbo.RepairOrders", "DescClient");
        }
    }
}
