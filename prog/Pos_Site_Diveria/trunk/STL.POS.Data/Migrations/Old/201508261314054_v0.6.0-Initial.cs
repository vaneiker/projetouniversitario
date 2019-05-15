namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v060Initial : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "POS.COVERAGE_DETAILS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverageDetailCoreId = c.Int(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinDeductible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SelfDamagesToProductLimits = c.Int(nullable: false),
                        ServicesToProductLimits = c.Int(nullable: false),
                        ThirdPartyToProductLimits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.SelfDamagesToProductLimits)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.ServicesToProductLimits)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.ThirdPartyToProductLimits)
                .Index(t => t.SelfDamagesToProductLimits)
                .Index(t => t.ServicesToProductLimits)
                .Index(t => t.ThirdPartyToProductLimits);
            
            CreateTable(
                "POS.DRIVERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 255),
                        PhoneNumber = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsPrincipal = c.Boolean(nullable: false),
                        Sex = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        WorkPhone = c.String(maxLength: 50),
                        License = c.String(maxLength: 50),
                        YearsDriving = c.Int(),
                        AccidentsLast3Years = c.String(maxLength: 5),
                        MaritalStatus = c.String(maxLength: 10),
                        Job = c.String(maxLength: 50),
                        Company = c.String(maxLength: 50),
                        YearsInCompany = c.Int(),
                        QuotationId = c.Int(nullable: false),
                        City_Country_Id = c.Int(nullable: false),
                        City_Domesticreg_Id = c.Int(nullable: false),
                        City_State_Prov_Id = c.Int(nullable: false),
                        City_City_Id = c.Int(nullable: false),
                        Nationality_Global_Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Global.ST_GLOBAL_CITY", t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.Nationality_Global_Country_Id)
                .ForeignKey("POS.QUOTATION", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .Index(t => t.Nationality_Global_Country_Id);
            
            CreateTable(
                "POS.PRODUCT_LIMITS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSelected = c.Boolean(nullable: false),
                        SdPrime = c.Decimal(storeType: "money"),
                        TpPrime = c.Decimal(storeType: "money"),
                        ServicesPrime = c.Decimal(storeType: "money"),
                        SelectedDeductibleCoreId = c.Int(nullable: false),
                        SelectedDeductibleName = c.String(),
                        VehicleProduct_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.VEHICLE_PRODUCT", t => t.VehicleProduct_Id)
                .Index(t => t.VehicleProduct_Id);
            
            CreateTable(
                "POS.QUOTATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductNumber = c.String(maxLength: 2),
                        QuotationDailyNumber = c.Int(nullable: false),
                        QuotationNumber = c.String(maxLength: 20),
                        PolicyNumber = c.String(maxLength: 20),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.Byte(nullable: false),
                        TermType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.TERM_TYPES", t => t.TermType_Id)
                .Index(t => t.TermType_Id);
            
            CreateTable(
                "POS.TERM_TYPES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        TimeSpanInMonths = c.Int(),
                        TimeSpanInLetters = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.VEHICLE_PRODUCT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Chassis = c.String(maxLength: 50),
                        Plate = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        VehiclePrice = c.Decimal(nullable: false, storeType: "money"),
                        InsuredAmount = c.Decimal(storeType: "money"),
                        PercentageToInsure = c.Decimal(precision: 5, scale: 2),
                        SelectedProductCoreId = c.Int(),
                        SelectedProductName = c.String(),
                        Driver_Id = c.Int(nullable: false),
                        Stored_Stored_Id = c.Int(nullable: false),
                        Usage_Usage_Id = c.Int(nullable: false),
                        VehicleVersion_Make_Id = c.Int(nullable: false),
                        VehicleVersion_Model_Id = c.Int(nullable: false),
                        VehicleVersion_Version_Id = c.Int(nullable: false),
                        Quotation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.DRIVERS", t => t.Driver_Id)
                .ForeignKey("POS.QUOTATION", t => t.Quotation_Id, cascadeDelete: true)
                .Index(t => t.Driver_Id)
                .Index(t => t.Stored_Stored_Id)
                .Index(t => t.Usage_Usage_Id)
                .Index(t => new { t.VehicleVersion_Make_Id, t.VehicleVersion_Model_Id, t.VehicleVersion_Version_Id })
                .Index(t => t.Quotation_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION");
            DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" }, "Global.ST_VEHICLE_VERSION");
            DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS");
            DropForeignKey("POS.QUOTATION", "TermType_Id", "POS.TERM_TYPES");
            DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION");
            DropForeignKey("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.COVERAGE_DETAILS", "ServicesToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Quotation_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Usage_Usage_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Stored_Stored_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Driver_Id" });
            DropIndex("POS.QUOTATION", new[] { "TermType_Id" });
            DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
            DropIndex("POS.DRIVERS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropIndex("POS.DRIVERS", new[] { "QuotationId" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ThirdPartyToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServicesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "SelfDamagesToProductLimits" });
            DropTable("POS.VEHICLE_PRODUCT");
            DropTable("POS.TERM_TYPES");
            DropTable("POS.QUOTATION");
            DropTable("POS.PRODUCT_LIMITS");
            DropTable("POS.DRIVERS");
            DropTable("POS.COVERAGE_DETAILS");
        }
    }
}
