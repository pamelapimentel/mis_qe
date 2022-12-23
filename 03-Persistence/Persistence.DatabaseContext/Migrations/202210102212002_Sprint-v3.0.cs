namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv30 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts");
            AddForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts");
            AddForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
    }
}
