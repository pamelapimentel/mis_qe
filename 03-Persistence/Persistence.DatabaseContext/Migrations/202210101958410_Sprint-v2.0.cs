namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Sprintv20 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contacts", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Contacts", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Accounts", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Accounts", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Leads", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Leads", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Opportunities", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Opportunities", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Quotes", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Quotes", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Products", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Products", name: "ModifiedById", newName: "DeletedBy");
            RenameColumn(table: "dbo.Tasks", name: "CreatedById", newName: "CreatedBy");
            RenameColumn(table: "dbo.Tasks", name: "ModifiedById", newName: "DeletedBy");
            RenameIndex(table: "dbo.Accounts", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Accounts", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Contacts", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Contacts", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Leads", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Leads", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Opportunities", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Opportunities", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Quotes", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Quotes", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Products", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            RenameIndex(table: "dbo.Tasks", name: "IX_CreatedById", newName: "IX_CreatedBy");
            RenameIndex(table: "dbo.Tasks", name: "IX_ModifiedById", newName: "IX_DeletedBy");
            AlterTableAnnotations(
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
                        DistrictId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Account_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ContactsPerAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryAccount = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ContactsPerAccount_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        DistrictId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Contact_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeadName = c.String(),
                        RankingLead = c.Int(nullable: false),
                        StatusLead = c.Int(nullable: false),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Lead_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        DistrictId = c.Int(),
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        LeadId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Opportunity_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.QuotesPerOpportunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        QuoteId = c.Int(nullable: false),
                        OpportunityId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_QuotesPerOpportunity_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(),
                        AccountId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Quote_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        GroupId = c.Int(nullable: false),
                        QuoteId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Product_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        QuoteId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ProductsBundle_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ProductsPerProductsBundles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        ProductsBundleId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ProductsPerProductsBundle_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Task_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Accounts", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Accounts", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Accounts", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Accounts", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ContactsPerAccounts", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ContactsPerAccounts", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ContactsPerAccounts", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ContactsPerAccounts", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ContactsPerAccounts", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ContactsPerAccounts", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Contacts", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Contacts", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Contacts", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Contacts", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Leads", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Leads", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Leads", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Leads", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Opportunities", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Opportunities", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Opportunities", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Opportunities", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.QuotesPerOpportunities", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.QuotesPerOpportunities", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.QuotesPerOpportunities", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.QuotesPerOpportunities", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.QuotesPerOpportunities", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.QuotesPerOpportunities", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Quotes", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Quotes", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Quotes", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Quotes", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Products", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Products", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ProductsBundles", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ProductsBundles", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsBundles", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ProductsBundles", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsBundles", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ProductsBundles", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsPerProductsBundles", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ProductsPerProductsBundles", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsPerProductsBundles", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ProductsPerProductsBundles", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.ProductsPerProductsBundles", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ProductsPerProductsBundles", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Tasks", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Tasks", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Tasks", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Tasks", "DeletedAt", c => c.DateTime());
            CreateIndex("dbo.Accounts", "UpdatedBy");
            CreateIndex("dbo.ContactsPerAccounts", "CreatedBy");
            CreateIndex("dbo.ContactsPerAccounts", "UpdatedBy");
            CreateIndex("dbo.ContactsPerAccounts", "DeletedBy");
            CreateIndex("dbo.Contacts", "UpdatedBy");
            CreateIndex("dbo.Leads", "UpdatedBy");
            CreateIndex("dbo.Opportunities", "UpdatedBy");
            CreateIndex("dbo.QuotesPerOpportunities", "CreatedBy");
            CreateIndex("dbo.QuotesPerOpportunities", "UpdatedBy");
            CreateIndex("dbo.QuotesPerOpportunities", "DeletedBy");
            CreateIndex("dbo.Quotes", "UpdatedBy");
            CreateIndex("dbo.Products", "UpdatedBy");
            CreateIndex("dbo.ProductsBundles", "CreatedBy");
            CreateIndex("dbo.ProductsBundles", "UpdatedBy");
            CreateIndex("dbo.ProductsBundles", "DeletedBy");
            CreateIndex("dbo.ProductsPerProductsBundles", "CreatedBy");
            CreateIndex("dbo.ProductsPerProductsBundles", "UpdatedBy");
            CreateIndex("dbo.ProductsPerProductsBundles", "DeletedBy");
            CreateIndex("dbo.Tasks", "UpdatedBy");
            AddForeignKey("dbo.Contacts", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ContactsPerAccounts", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ContactsPerAccounts", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ContactsPerAccounts", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Accounts", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Leads", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.QuotesPerOpportunities", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.QuotesPerOpportunities", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Quotes", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.QuotesPerOpportunities", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Opportunities", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Products", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsBundles", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsBundles", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsPerProductsBundles", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsPerProductsBundles", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsPerProductsBundles", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ProductsBundles", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Tasks", "UpdatedBy", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Accounts", "DateEntered");
            DropColumn("dbo.Accounts", "DateModified");
            DropColumn("dbo.ContactsPerAccounts", "DateModified");
            DropColumn("dbo.Contacts", "DateEntered");
            DropColumn("dbo.Contacts", "DateModified");
            DropColumn("dbo.Leads", "DateEntered");
            DropColumn("dbo.Leads", "DateModified");
            DropColumn("dbo.Opportunities", "DateEntered");
            DropColumn("dbo.Opportunities", "DateModified");
            DropColumn("dbo.QuotesPerOpportunities", "DateEntered");
            DropColumn("dbo.QuotesPerOpportunities", "DateModified");
            DropColumn("dbo.Quotes", "DateEntered");
            DropColumn("dbo.Quotes", "DateModified");
            DropColumn("dbo.Products", "DateEntered");
            DropColumn("dbo.Products", "DateModified");
            DropColumn("dbo.ProductsBundles", "DateEntered");
            DropColumn("dbo.ProductsBundles", "DateModified");
            DropColumn("dbo.ProductsPerProductsBundles", "DateEntered");
            DropColumn("dbo.ProductsPerProductsBundles", "DateModified");
            DropColumn("dbo.Tasks", "DateEntered");
            DropColumn("dbo.Tasks", "DateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductsPerProductsBundles", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductsPerProductsBundles", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductsBundles", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductsBundles", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Quotes", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Quotes", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuotesPerOpportunities", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuotesPerOpportunities", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Opportunities", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Opportunities", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Leads", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "DateEntered", c => c.DateTime(nullable: false));
            AddColumn("dbo.ContactsPerAccounts", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Accounts", "DateEntered", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Tasks", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsBundles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsPerProductsBundles", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsPerProductsBundles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsPerProductsBundles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsBundles", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductsBundles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opportunities", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuotesPerOpportunities", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuotesPerOpportunities", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.QuotesPerOpportunities", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leads", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactsPerAccounts", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactsPerAccounts", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ContactsPerAccounts", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Tasks", new[] { "UpdatedBy" });
            DropIndex("dbo.ProductsPerProductsBundles", new[] { "DeletedBy" });
            DropIndex("dbo.ProductsPerProductsBundles", new[] { "UpdatedBy" });
            DropIndex("dbo.ProductsPerProductsBundles", new[] { "CreatedBy" });
            DropIndex("dbo.ProductsBundles", new[] { "DeletedBy" });
            DropIndex("dbo.ProductsBundles", new[] { "UpdatedBy" });
            DropIndex("dbo.ProductsBundles", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "UpdatedBy" });
            DropIndex("dbo.Quotes", new[] { "UpdatedBy" });
            DropIndex("dbo.QuotesPerOpportunities", new[] { "DeletedBy" });
            DropIndex("dbo.QuotesPerOpportunities", new[] { "UpdatedBy" });
            DropIndex("dbo.QuotesPerOpportunities", new[] { "CreatedBy" });
            DropIndex("dbo.Opportunities", new[] { "UpdatedBy" });
            DropIndex("dbo.Leads", new[] { "UpdatedBy" });
            DropIndex("dbo.Contacts", new[] { "UpdatedBy" });
            DropIndex("dbo.ContactsPerAccounts", new[] { "DeletedBy" });
            DropIndex("dbo.ContactsPerAccounts", new[] { "UpdatedBy" });
            DropIndex("dbo.ContactsPerAccounts", new[] { "CreatedBy" });
            DropIndex("dbo.Accounts", new[] { "UpdatedBy" });
            DropColumn("dbo.Tasks", "DeletedAt");
            DropColumn("dbo.Tasks", "UpdatedBy");
            DropColumn("dbo.Tasks", "UpdatedAt");
            DropColumn("dbo.Tasks", "CreatedAt");
            DropColumn("dbo.ProductsPerProductsBundles", "DeletedBy");
            DropColumn("dbo.ProductsPerProductsBundles", "DeletedAt");
            DropColumn("dbo.ProductsPerProductsBundles", "UpdatedBy");
            DropColumn("dbo.ProductsPerProductsBundles", "UpdatedAt");
            DropColumn("dbo.ProductsPerProductsBundles", "CreatedBy");
            DropColumn("dbo.ProductsPerProductsBundles", "CreatedAt");
            DropColumn("dbo.ProductsBundles", "DeletedBy");
            DropColumn("dbo.ProductsBundles", "DeletedAt");
            DropColumn("dbo.ProductsBundles", "UpdatedBy");
            DropColumn("dbo.ProductsBundles", "UpdatedAt");
            DropColumn("dbo.ProductsBundles", "CreatedBy");
            DropColumn("dbo.ProductsBundles", "CreatedAt");
            DropColumn("dbo.Products", "DeletedAt");
            DropColumn("dbo.Products", "UpdatedBy");
            DropColumn("dbo.Products", "UpdatedAt");
            DropColumn("dbo.Products", "CreatedAt");
            DropColumn("dbo.Quotes", "DeletedAt");
            DropColumn("dbo.Quotes", "UpdatedBy");
            DropColumn("dbo.Quotes", "UpdatedAt");
            DropColumn("dbo.Quotes", "CreatedAt");
            DropColumn("dbo.QuotesPerOpportunities", "DeletedBy");
            DropColumn("dbo.QuotesPerOpportunities", "DeletedAt");
            DropColumn("dbo.QuotesPerOpportunities", "UpdatedBy");
            DropColumn("dbo.QuotesPerOpportunities", "UpdatedAt");
            DropColumn("dbo.QuotesPerOpportunities", "CreatedBy");
            DropColumn("dbo.QuotesPerOpportunities", "CreatedAt");
            DropColumn("dbo.Opportunities", "DeletedAt");
            DropColumn("dbo.Opportunities", "UpdatedBy");
            DropColumn("dbo.Opportunities", "UpdatedAt");
            DropColumn("dbo.Opportunities", "CreatedAt");
            DropColumn("dbo.Leads", "DeletedAt");
            DropColumn("dbo.Leads", "UpdatedBy");
            DropColumn("dbo.Leads", "UpdatedAt");
            DropColumn("dbo.Leads", "CreatedAt");
            DropColumn("dbo.Contacts", "DeletedAt");
            DropColumn("dbo.Contacts", "UpdatedBy");
            DropColumn("dbo.Contacts", "UpdatedAt");
            DropColumn("dbo.Contacts", "CreatedAt");
            DropColumn("dbo.ContactsPerAccounts", "DeletedBy");
            DropColumn("dbo.ContactsPerAccounts", "DeletedAt");
            DropColumn("dbo.ContactsPerAccounts", "UpdatedBy");
            DropColumn("dbo.ContactsPerAccounts", "UpdatedAt");
            DropColumn("dbo.ContactsPerAccounts", "CreatedBy");
            DropColumn("dbo.ContactsPerAccounts", "CreatedAt");
            DropColumn("dbo.Accounts", "DeletedAt");
            DropColumn("dbo.Accounts", "UpdatedBy");
            DropColumn("dbo.Accounts", "UpdatedAt");
            DropColumn("dbo.Accounts", "CreatedAt");
            AlterTableAnnotations(
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
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Task_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ProductsPerProductsBundles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        ProductsBundleId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ProductsPerProductsBundle_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        QuoteId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ProductsBundle_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        GroupId = c.Int(nullable: false),
                        QuoteId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Product_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(),
                        AccountId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Quote_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.QuotesPerOpportunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Deleted = c.Boolean(nullable: false),
                        QuoteId = c.Int(nullable: false),
                        OpportunityId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_QuotesPerOpportunity_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        DistrictId = c.Int(),
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        LeadId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Opportunity_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Leads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeadName = c.String(),
                        RankingLead = c.Int(nullable: false),
                        StatusLead = c.Int(nullable: false),
                        Description = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        AssignedUserId = c.String(maxLength: 128),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Lead_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        DistrictId = c.Int(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Contact_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ContactsPerAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PrimaryAccount = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        ContactId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ContactsPerAccount_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        DistrictId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Account_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            RenameIndex(table: "dbo.Tasks", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Tasks", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Products", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Products", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Quotes", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Quotes", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Opportunities", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Opportunities", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Leads", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Leads", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Contacts", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Contacts", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameIndex(table: "dbo.Accounts", name: "IX_DeletedBy", newName: "IX_ModifiedById");
            RenameIndex(table: "dbo.Accounts", name: "IX_CreatedBy", newName: "IX_CreatedById");
            RenameColumn(table: "dbo.Tasks", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Tasks", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Products", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Products", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Quotes", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Quotes", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Opportunities", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Opportunities", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Leads", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Leads", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Accounts", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Accounts", name: "CreatedBy", newName: "CreatedById");
            RenameColumn(table: "dbo.Contacts", name: "DeletedBy", newName: "ModifiedById");
            RenameColumn(table: "dbo.Contacts", name: "CreatedBy", newName: "CreatedById");
        }
    }
}
