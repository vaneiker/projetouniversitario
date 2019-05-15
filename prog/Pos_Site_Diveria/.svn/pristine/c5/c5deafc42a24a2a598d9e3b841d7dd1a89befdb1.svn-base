using System;
using System.Data.Entity.Migrations;

public partial class Initial_v050 : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "POS.ADDITIONAL_PRODUCTS",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    IsSelected = c.Boolean(nullable: false),
                    Name = c.String(maxLength: 50),
                    Description = c.String(maxLength: 200),
                    Prime = c.Decimal(storeType: "money"),
                    ProductLimits_Id = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("POS.PRODUCT_LIMITS", t => t.ProductLimits_Id)
            .Index(t => t.ProductLimits_Id);       
        
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
                    AccidentsLast3Years = c.Int(),
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
                    MinDeductible = c.Decimal(precision: 18, scale: 2),
                    OthersProperty = c.Decimal(nullable: false, storeType: "money"),
                    OnePersonDeath = c.Decimal(nullable: false, storeType: "money"),
                    AnotherPersonDeath = c.Decimal(nullable: false, storeType: "money"),
                    PassengerDeath = c.Decimal(nullable: false, storeType: "money"),
                    AnotherPassengerDeath = c.Decimal(nullable: false, storeType: "money"),
                    Bail = c.Decimal(nullable: false, storeType: "money"),
                    SdPrime = c.Decimal(storeType: "money"),
                    DriverRisk = c.Decimal(storeType: "money"),
                    CollisionRollover = c.Decimal(storeType: "money"),
                    FireTheft = c.Decimal(storeType: "money"),
                    ComprehensiveRisk = c.Decimal(storeType: "money"),
                    GlassBreakage = c.Decimal(storeType: "money"),
                    SpecialEquipment = c.Decimal(storeType: "money"),
                    TpPrime = c.Decimal(storeType: "money"),
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
                })
            .PrimaryKey(t => t.Id);
        
        CreateTable(
            "POS.VEHICLE_PRODUCT",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MakeId = c.Int(nullable: false),
                    ModelId = c.Int(nullable: false),
                    VersionId = c.Int(nullable: false),
                    QuotationId = c.Int(nullable: false),
                    DriverId = c.Int(nullable: false),
                    UsageId = c.Int(nullable: false),
                    StoredId = c.Int(nullable: false),
                    Chassis = c.String(maxLength: 50),
                    Plate = c.String(maxLength: 50),
                    Color = c.String(maxLength: 50),
                    VehiclePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    EnsuredAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PercentageToEnsure = c.Decimal(precision: 5, scale: 2),
                    OthersPropertyLimits = c.String(),
                    OnePersonDeathLimits = c.String(),
                    AnotherPersonDeathLimits = c.String(),
                    PassengerDeathLimits = c.String(),
                    AnotherPassengerDeathLimits = c.String(),
                    BailLimits = c.String(),
                    DriverRiskLimits = c.String(),
                    CollisionRolloverLimits = c.String(),
                    FireTheftLimits = c.String(),
                    ComprehensiveRiskLimits = c.String(),
                    GlassBreakageLimits = c.String(),
                    SpecialEquipmentLimits = c.String(),
                    SelectedProduct_Corp_Id = c.Int(),
                    SelectedProduct_Group_Id = c.Int(),
                    SelectedProduct_Group_Desc = c.String(maxLength: 200, unicode: false),
                    SelectedProduct_Group_Status = c.Boolean(),
                    SelectedProduct_Create_Date = c.DateTime(),
                    SelectedProduct_Create_UsrId = c.Int(),
                    SelectedProduct_hostname = c.String(maxLength: 100, unicode: false),
                    SelectedProduct_Core_Group_Id = c.Int(),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("POS.DRIVERS", t => t.DriverId)
            .ForeignKey("Global.ST_VEHICLE_STORED", t => t.StoredId)
            .ForeignKey("Global.ST_VEHICLE_USAGE", t => t.UsageId)
            .ForeignKey("Global.ST_VEHICLE_VERSION", t => new { t.MakeId, t.ModelId, t.VersionId })
            .ForeignKey("POS.QUOTATION", t => t.QuotationId, cascadeDelete: true)
            .Index(t => new { t.MakeId, t.ModelId, t.VersionId })
            .Index(t => t.QuotationId)
            .Index(t => t.DriverId)
            .Index(t => t.UsageId)
            .Index(t => t.StoredId)
            .Index(t => new { t.SelectedProduct_Corp_Id, t.SelectedProduct_Group_Id, t.SelectedProduct_Group_Desc, t.SelectedProduct_Group_Status, t.SelectedProduct_Create_Date, t.SelectedProduct_Create_UsrId, t.SelectedProduct_hostname, t.SelectedProduct_Core_Group_Id });
        
   
    }
    
    public override void Down()
    {
        DropForeignKey("POS.VEHICLE_PRODUCT", "QuotationId", "POS.QUOTATION");
        DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "MakeId", "ModelId", "VersionId" }, "Global.ST_VEHICLE_VERSION");
        DropForeignKey("POS.VEHICLE_PRODUCT", "UsageId", "Global.ST_VEHICLE_USAGE");
        DropForeignKey("POS.VEHICLE_PRODUCT", "StoredId", "Global.ST_VEHICLE_STORED");
        DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" }, "Integration.VW_ST_COVERAGES_GROUP");
        DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
        DropForeignKey("POS.VEHICLE_PRODUCT", "DriverId", "POS.DRIVERS");
        DropForeignKey("POS.QUOTATION", "TermType_Id", "POS.TERM_TYPES");
        DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION");
        DropForeignKey("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id", "POS.PRODUCT_LIMITS");
        DropForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
        DropForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" });
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "StoredId" });
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "UsageId" });
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "DriverId" });
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "QuotationId" });
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "MakeId", "ModelId", "VersionId" });
        DropIndex("POS.QUOTATION", new[] { "TermType_Id" });
        DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
        DropIndex("POS.DRIVERS", new[] { "Nationality_Global_Country_Id" });
        DropIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
        DropIndex("POS.DRIVERS", new[] { "QuotationId" });
        DropIndex("POS.ADDITIONAL_PRODUCTS", new[] { "ProductLimits_Id" });
        DropTable("POS.VEHICLE_PRODUCT");
        DropTable("POS.TERM_TYPES");
        DropTable("POS.QUOTATION");
        DropTable("POS.PRODUCT_LIMITS");
        DropTable("POS.DRIVERS");
        DropTable("POS.ADDITIONAL_PRODUCTS");
    }
}
