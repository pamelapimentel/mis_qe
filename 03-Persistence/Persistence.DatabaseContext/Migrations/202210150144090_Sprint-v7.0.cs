namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv70 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leads", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Leads", "Currency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leads", "Currency");
            DropColumn("dbo.Leads", "Amount");
        }
    }
}
