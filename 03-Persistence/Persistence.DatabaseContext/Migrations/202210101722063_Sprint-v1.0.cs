namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Industry = c.Int(nullable: false),
                        Sector = c.Int(nullable: false),
                        PhoneOffice = c.String(),
                        PhoneAlternate = c.String(),
                        WebSite = c.String(),
                        PhoneWork = c.String(),
                        PhoneMobile = c.String(),
                        AddressStreet = c.String(),
                        Email = c.String(),
                        Origin = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DistrictId = c.Int(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.DistrictId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.ContactsPerAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryAccount = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salutation = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        FatherLastName = c.String(),
                        MotherLastName = c.String(),
                        JobTitle = c.String(),
                        Department = c.String(),
                        PhoneWork = c.String(),
                        PhoneMobile = c.String(),
                        AddressStreet = c.String(),
                        Birthdate = c.String(),
                        Email = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DistrictId = c.Int(),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.DistrictId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Description = c.String(),
                        LineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .Index(t => t.LineId);
            
            CreateTable(
                "dbo.Lines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LineName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeadName = c.String(),
                        RankingLead = c.Int(nullable: false),
                        StatusLead = c.Int(nullable: false),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AssignedUserId = c.String(maxLength: 128),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedUserId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.AssignedUserId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ContactId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Opportunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpportunityName = c.String(),
                        ProbabilityOpportunity = c.Int(nullable: false),
                        SolutionType = c.Int(nullable: false),
                        StatusOpportunity = c.Int(nullable: false),
                        Description = c.String(),
                        StageOpportunity = c.Int(nullable: false),
                        DateClosed = c.DateTime(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        AddressStreet = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        DistrictId = c.Int(),
                        AssignedUserId = c.String(maxLength: 128),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        LeadId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedUserId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Districts", t => t.DistrictId)
                .ForeignKey("dbo.Leads", t => t.LeadId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.DistrictId)
                .Index(t => t.AssignedUserId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ContactId)
                .Index(t => t.AccountId)
                .Index(t => t.LeadId);
            
            CreateTable(
                "dbo.QuotesPerOpportunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        QuoteId = c.Int(nullable: false),
                        OpportunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Opportunities", t => t.OpportunityId, cascadeDelete: true)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId)
                .Index(t => t.OpportunityId);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuoteNum = c.String(),
                        StatusQuote = c.Int(nullable: false),
                        Version = c.String(),
                        Comments = c.String(),
                        DateQuoteClosed = c.DateTime(),
                        PaymentTerms = c.String(),
                        DeliveryConditions = c.Int(nullable: false),
                        Observations = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AssignedUserId = c.String(maxLength: 128),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                        ContactId = c.Int(),
                        AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedUserId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.AssignedUserId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ContactId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Description = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountRatePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        UnitProduct = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                        GroupId = c.Int(nullable: false),
                        QuoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.GroupId)
                .Index(t => t.QuoteId);
            
            CreateTable(
                "dbo.ProductsBundles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductsBundleName = c.String(),
                        Description = c.String(),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountRatePercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        QuoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quotes", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId);
            
            CreateTable(
                "dbo.ProductsPerProductsBundles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        ProductsBundleId = c.Int(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductsBundles", t => t.ProductsBundleId)
                .Index(t => t.ProductsBundleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        StatusTask = c.Int(nullable: false),
                        Description = c.String(),
                        DateLimit = c.DateTime(),
                        PriorityTask = c.Int(nullable: false),
                        TypeTask = c.Int(nullable: false),
                        ParentType = c.String(),
                        EntityType = c.Int(nullable: false),
                        EntityId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AssignedUserId = c.String(maxLength: 128),
                        CreatedById = c.String(maxLength: 128),
                        ModifiedById = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AssignedUserId)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedById)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedById)
                .Index(t => t.AssignedUserId)
                .Index(t => t.CreatedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ContactId)
                .Index(t => t.AccountId);
            
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FatherLastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MotherLastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "StatusUser", c => c.Int());
            AddColumn("dbo.AspNetUsers", "AddressStreet", c => c.String());
            AddColumn("dbo.AspNetUsers", "DistrictId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DistrictId");
            AddForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Tasks", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tasks", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.ProductsBundles", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.ProductsPerProductsBundles", "ProductsBundleId", "dbo.ProductsBundles");
            DropForeignKey("dbo.ProductsPerProductsBundles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Products", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Products", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuotesPerOpportunities", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Quotes", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Quotes", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.QuotesPerOpportunities", "OpportunityId", "dbo.Opportunities");
            DropForeignKey("dbo.Opportunities", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opportunities", "LeadId", "dbo.Leads");
            DropForeignKey("dbo.Opportunities", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Opportunities", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opportunities", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Opportunities", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opportunities", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Leads", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leads", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leads", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Leads", "AssignedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leads", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Groups", "LineId", "dbo.Lines");
            DropForeignKey("dbo.Accounts", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Accounts", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactsPerAccounts", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "ModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Contacts", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "StateId", "dbo.States");
            DropForeignKey("dbo.ContactsPerAccounts", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Tasks", new[] { "AccountId" });
            DropIndex("dbo.Tasks", new[] { "ContactId" });
            DropIndex("dbo.Tasks", new[] { "ModifiedById" });
            DropIndex("dbo.Tasks", new[] { "CreatedById" });
            DropIndex("dbo.Tasks", new[] { "AssignedUserId" });
            DropIndex("dbo.ProductsPerProductsBundles", new[] { "ProductId" });
            DropIndex("dbo.ProductsPerProductsBundles", new[] { "ProductsBundleId" });
            DropIndex("dbo.ProductsBundles", new[] { "QuoteId" });
            DropIndex("dbo.Products", new[] { "QuoteId" });
            DropIndex("dbo.Products", new[] { "GroupId" });
            DropIndex("dbo.Products", new[] { "ModifiedById" });
            DropIndex("dbo.Products", new[] { "CreatedById" });
            DropIndex("dbo.Quotes", new[] { "AccountId" });
            DropIndex("dbo.Quotes", new[] { "ContactId" });
            DropIndex("dbo.Quotes", new[] { "ModifiedById" });
            DropIndex("dbo.Quotes", new[] { "CreatedById" });
            DropIndex("dbo.Quotes", new[] { "AssignedUserId" });
            DropIndex("dbo.QuotesPerOpportunities", new[] { "OpportunityId" });
            DropIndex("dbo.QuotesPerOpportunities", new[] { "QuoteId" });
            DropIndex("dbo.Opportunities", new[] { "LeadId" });
            DropIndex("dbo.Opportunities", new[] { "AccountId" });
            DropIndex("dbo.Opportunities", new[] { "ContactId" });
            DropIndex("dbo.Opportunities", new[] { "ModifiedById" });
            DropIndex("dbo.Opportunities", new[] { "CreatedById" });
            DropIndex("dbo.Opportunities", new[] { "AssignedUserId" });
            DropIndex("dbo.Opportunities", new[] { "DistrictId" });
            DropIndex("dbo.Leads", new[] { "AccountId" });
            DropIndex("dbo.Leads", new[] { "ContactId" });
            DropIndex("dbo.Leads", new[] { "ModifiedById" });
            DropIndex("dbo.Leads", new[] { "CreatedById" });
            DropIndex("dbo.Leads", new[] { "AssignedUserId" });
            DropIndex("dbo.Groups", new[] { "LineId" });
            DropIndex("dbo.Cities", new[] { "StateId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.AspNetUsers", new[] { "DistrictId" });
            DropIndex("dbo.Contacts", new[] { "ModifiedById" });
            DropIndex("dbo.Contacts", new[] { "CreatedById" });
            DropIndex("dbo.Contacts", new[] { "DistrictId" });
            DropIndex("dbo.ContactsPerAccounts", new[] { "AccountId" });
            DropIndex("dbo.ContactsPerAccounts", new[] { "ContactId" });
            DropIndex("dbo.Accounts", new[] { "ModifiedById" });
            DropIndex("dbo.Accounts", new[] { "CreatedById" });
            DropIndex("dbo.Accounts", new[] { "DistrictId" });
            DropColumn("dbo.AspNetUsers", "DistrictId");
            DropColumn("dbo.AspNetUsers", "AddressStreet");
            DropColumn("dbo.AspNetUsers", "StatusUser");
            DropColumn("dbo.AspNetUsers", "MotherLastName");
            DropColumn("dbo.AspNetUsers", "FatherLastName");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Description");
            DropTable("dbo.Tasks");
            DropTable("dbo.ProductsPerProductsBundles");
            DropTable("dbo.ProductsBundles");
            DropTable("dbo.Products");
            DropTable("dbo.Quotes");
            DropTable("dbo.QuotesPerOpportunities");
            DropTable("dbo.Opportunities");
            DropTable("dbo.Leads");
            DropTable("dbo.Lines");
            DropTable("dbo.Groups");
            DropTable("dbo.States");
            DropTable("dbo.Cities");
            DropTable("dbo.Districts");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactsPerAccounts");
            DropTable("dbo.Accounts");
        }
    }
}
