namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tst : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RepairOrderParts", newName: "PartRepairOrders");
            DropPrimaryKey("dbo.PartRepairOrders");
            AddColumn("dbo.RepairOrders", "Technician_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.RepairOrders", "CustomerId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.PartRepairOrders", new[] { "Part_Id", "RepairOrder_Id" });
            CreateIndex("dbo.RepairOrders", "CustomerId");
            CreateIndex("dbo.RepairOrders", "Technician_Id");
            AddForeignKey("dbo.RepairOrders", "CustomerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.RepairOrders", "Technician_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairOrders", "Technician_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RepairOrders", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.RepairOrders", new[] { "Technician_Id" });
            DropIndex("dbo.RepairOrders", new[] { "CustomerId" });
            DropPrimaryKey("dbo.PartRepairOrders");
            AlterColumn("dbo.RepairOrders", "CustomerId", c => c.String());
            DropColumn("dbo.RepairOrders", "Technician_Id");
            AddPrimaryKey("dbo.PartRepairOrders", new[] { "RepairOrder_Id", "Part_Id" });
            RenameTable(name: "dbo.PartRepairOrders", newName: "RepairOrderParts");
        }
    }
}
