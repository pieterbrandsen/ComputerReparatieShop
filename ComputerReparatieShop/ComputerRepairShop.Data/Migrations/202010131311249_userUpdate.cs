namespace ComputerRepairShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "YearOfbirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "YearOfbirth", c => c.DateTime(nullable: false));
        }
    }
}
