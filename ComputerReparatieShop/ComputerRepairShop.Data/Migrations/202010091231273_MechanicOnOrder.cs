namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MechanicOnOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RepairOrders", "Description_Client", c => c.String());
            AddColumn("dbo.RepairOrders", "Description_Mechanic", c => c.String());
            AddColumn("dbo.RepairOrders", "Assigned", c => c.String());
            DropColumn("dbo.RepairOrders", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairOrders", "Description", c => c.String());
            DropColumn("dbo.RepairOrders", "Assigned");
            DropColumn("dbo.RepairOrders", "Description_Mechanic");
            DropColumn("dbo.RepairOrders", "Description_Client");
        }
    }
}
