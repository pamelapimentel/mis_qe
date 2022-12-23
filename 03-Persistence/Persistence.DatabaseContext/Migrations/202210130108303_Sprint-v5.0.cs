namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv50 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Accounts", new[] { "DistrictId" });
            AlterColumn("dbo.Accounts", "DistrictId", c => c.Int());
            CreateIndex("dbo.Accounts", "DistrictId");
            AddForeignKey("dbo.Accounts", "DistrictId", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "DistrictId", "dbo.Districts");
            DropIndex("dbo.Accounts", new[] { "DistrictId" });
            AlterColumn("dbo.Accounts", "DistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "DistrictId");
            AddForeignKey("dbo.Accounts", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
    }
}
