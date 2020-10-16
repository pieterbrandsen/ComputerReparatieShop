namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableNameUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Parts", newName: "PartModels");
            RenameTable(name: "dbo.PartRepairOrders", newName: "PartModelRepairOrders");
            RenameColumn(table: "dbo.PartModelRepairOrders", name: "Part_Id", newName: "PartModel_Id");
            RenameIndex(table: "dbo.PartModelRepairOrders", name: "IX_Part_Id", newName: "IX_PartModel_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PartModelRepairOrders", name: "IX_PartModel_Id", newName: "IX_Part_Id");
            RenameColumn(table: "dbo.PartModelRepairOrders", name: "PartModel_Id", newName: "Part_Id");
            RenameTable(name: "dbo.PartModelRepairOrders", newName: "PartRepairOrders");
            RenameTable(name: "dbo.PartModels", newName: "Parts");
        }
    }
}
