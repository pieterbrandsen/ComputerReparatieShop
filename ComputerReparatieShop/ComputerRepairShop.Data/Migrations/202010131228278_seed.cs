namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "ProductName", c => c.String());
            AddColumn("dbo.Parts", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "Nickname");
            DropColumn("dbo.Parts", "ProductName");
        }
    }
}
