namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddescriptionsfromtechnicanandcustomerforrepairOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrders", "DescCustomer", c => c.String());
            AddColumn("dbo.RepairOrders", "DescTechnican", c => c.String());
            DropColumn("dbo.RepairOrders", "DescClient");
            DropColumn("dbo.RepairOrders", "DescMechanic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairOrders", "DescMechanic", c => c.String());
            AddColumn("dbo.RepairOrders", "DescClient", c => c.String());
            DropColumn("dbo.RepairOrders", "DescTechnican");
            DropColumn("dbo.RepairOrders", "DescCustomer");
        }
    }
}
