namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountAvaiable = c.Short(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Manufacturer = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairOrderParts",
                c => new
                    {
                        RepairOrder_Id = c.Int(nullable: false),
                        Part_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepairOrder_Id, t.Part_Id })
                .ForeignKey("dbo.RepairOrders", t => t.RepairOrder_Id, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.Part_Id, cascadeDelete: true)
                .Index(t => t.RepairOrder_Id)
                .Index(t => t.Part_Id);
            
            AlterColumn("dbo.AspNetUsers", "Wage", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairOrderParts", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.RepairOrderParts", "RepairOrder_Id", "dbo.RepairOrders");
            DropIndex("dbo.RepairOrderParts", new[] { "Part_Id" });
            DropIndex("dbo.RepairOrderParts", new[] { "RepairOrder_Id" });
            AlterColumn("dbo.AspNetUsers", "Wage", c => c.Int());
            DropTable("dbo.RepairOrderParts");
            DropTable("dbo.Parts");
        }
    }
}
