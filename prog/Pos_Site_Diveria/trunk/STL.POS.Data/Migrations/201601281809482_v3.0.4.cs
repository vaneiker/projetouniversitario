namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v304 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.PRODUCT_TYPE_FAMILY_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        BusinessLine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.BUSINESS_LINE", t => t.BusinessLine_Id)
                .Index(t => t.BusinessLine_Id);
            
            CreateTable(
                "POS.PRODUCT_TYPE_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ProductTypeFamilyBrochure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PRODUCT_TYPE_FAMILY_BROCHURE", t => t.ProductTypeFamilyBrochure_Id)
                .Index(t => t.ProductTypeFamilyBrochure_Id);
            
            CreateTable(
                "POS.BENEFITS_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        ProductTypeBrochure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PRODUCT_TYPE_BROCHURE", t => t.ProductTypeBrochure_Id)
                .Index(t => t.ProductTypeBrochure_Id);
            
            CreateTable(
                "POS.COVERAGE_TYPES_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ProductTypeBrochure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PRODUCT_TYPE_BROCHURE", t => t.ProductTypeBrochure_Id)
                .Index(t => t.ProductTypeBrochure_Id);
            
            CreateTable(
                "POS.COVERAGES_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CoverageTypeBrochure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.COVERAGE_TYPES_BROCHURE", t => t.CoverageTypeBrochure_Id)
                .Index(t => t.CoverageTypeBrochure_Id);
            
            CreateTable(
                "POS.COVERAGE_DETAILS_BROCHURE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Value = c.Decimal(nullable: false, storeType: "money"),
                        CoverageBrochure_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.COVERAGES_BROCHURE", t => t.CoverageBrochure_Id)
                .Index(t => t.CoverageBrochure_Id);
            
            CreateTable(
                "POS.CURRENCIES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(maxLength: 5),
                        Name = c.String(maxLength: 50),
                        CardnetCode = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.CHANGE_RATES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Decimal(nullable: false, storeType: "money"),
                        Currency_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.CURRENCIES", t => t.Currency_Id)
                .Index(t => t.Currency_Id);
            
            CreateTable(
                "POS.ProductTypeBrochureCurrencies",
                c => new
                    {
                        ProductTypeBrochure_Id = c.Int(nullable: false),
                        Currency_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductTypeBrochure_Id, t.Currency_Id })
                .ForeignKey("POS.PRODUCT_TYPE_BROCHURE", t => t.ProductTypeBrochure_Id, cascadeDelete: true)
                .ForeignKey("POS.CURRENCIES", t => t.Currency_Id, cascadeDelete: true)
                .Index(t => t.ProductTypeBrochure_Id)
                .Index(t => t.Currency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("POS.PRODUCT_TYPE_FAMILY_BROCHURE", "BusinessLine_Id", "POS.BUSINESS_LINE");
            DropForeignKey("POS.PRODUCT_TYPE_BROCHURE", "ProductTypeFamilyBrochure_Id", "POS.PRODUCT_TYPE_FAMILY_BROCHURE");
            DropForeignKey("POS.ProductTypeBrochureCurrencies", "Currency_Id", "POS.CURRENCIES");
            DropForeignKey("POS.ProductTypeBrochureCurrencies", "ProductTypeBrochure_Id", "POS.PRODUCT_TYPE_BROCHURE");
            DropForeignKey("POS.CHANGE_RATES", "Currency_Id", "POS.CURRENCIES");
            DropForeignKey("POS.COVERAGE_TYPES_BROCHURE", "ProductTypeBrochure_Id", "POS.PRODUCT_TYPE_BROCHURE");
            DropForeignKey("POS.COVERAGES_BROCHURE", "CoverageTypeBrochure_Id", "POS.COVERAGE_TYPES_BROCHURE");
            DropForeignKey("POS.COVERAGE_DETAILS_BROCHURE", "CoverageBrochure_Id", "POS.COVERAGES_BROCHURE");
            DropForeignKey("POS.BENEFITS_BROCHURE", "ProductTypeBrochure_Id", "POS.PRODUCT_TYPE_BROCHURE");
            DropIndex("POS.ProductTypeBrochureCurrencies", new[] { "Currency_Id" });
            DropIndex("POS.ProductTypeBrochureCurrencies", new[] { "ProductTypeBrochure_Id" });
            DropIndex("POS.CHANGE_RATES", new[] { "Currency_Id" });
            DropIndex("POS.COVERAGE_DETAILS_BROCHURE", new[] { "CoverageBrochure_Id" });
            DropIndex("POS.COVERAGES_BROCHURE", new[] { "CoverageTypeBrochure_Id" });
            DropIndex("POS.COVERAGE_TYPES_BROCHURE", new[] { "ProductTypeBrochure_Id" });
            DropIndex("POS.BENEFITS_BROCHURE", new[] { "ProductTypeBrochure_Id" });
            DropIndex("POS.PRODUCT_TYPE_BROCHURE", new[] { "ProductTypeFamilyBrochure_Id" });
            DropIndex("POS.PRODUCT_TYPE_FAMILY_BROCHURE", new[] { "BusinessLine_Id" });
            DropTable("POS.ProductTypeBrochureCurrencies");
            DropTable("POS.CHANGE_RATES");
            DropTable("POS.CURRENCIES");
            DropTable("POS.COVERAGE_DETAILS_BROCHURE");
            DropTable("POS.COVERAGES_BROCHURE");
            DropTable("POS.COVERAGE_TYPES_BROCHURE");
            DropTable("POS.BENEFITS_BROCHURE");
            DropTable("POS.PRODUCT_TYPE_BROCHURE");
            DropTable("POS.PRODUCT_TYPE_FAMILY_BROCHURE");
        }
    }
}
