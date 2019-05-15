namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v010 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.QUOTATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.DRIVERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 255),
                        PhoneNumber = c.String(maxLength: 50),
                        CityId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsPrincipal = c.Boolean(nullable: false),
                        Sex = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        WorkPhone = c.String(maxLength: 50),
                        License = c.String(maxLength: 50),
                        YearsDriving = c.Int(nullable: false),
                        AccidentsLast3Years = c.Int(nullable: false),
                        MaritalStatus = c.String(maxLength: 10),
                        Nationality = c.String(maxLength: 50),
                        Job = c.String(maxLength: 50),
                        Company = c.String(maxLength: 50),
                        YearsInCompany = c.Int(nullable: false),
                        QuotationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.QUOTATION", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.QuotationId);
            
            CreateTable(
                "POS.VEHICLE_INFO",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                        QuotationId = c.Int(nullable: false),
                        VehicleInfoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.DRIVERS", t => t.VehicleInfoId)
                .ForeignKey("POS.QUOTATION", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => t.VehicleInfoId);
            
            CreateTable(
                "POS.ADDITIONALPRODUCTS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        VehicleInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.VEHICLE_INFO", t => t.VehicleInfoId, cascadeDelete: true)
                .Index(t => t.VehicleInfoId);
            
            CreateTable(
                "POS.ADDITIONALPRODUCTOPTIONS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Prime = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.ADDITIONALPRODUCTS", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "POS.COVERAGES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Selected = c.Boolean(nullable: false),
                        Product = c.String(),
                        OthersProperty = c.Decimal(nullable: false, storeType: "money"),
                        OnePersonDeath = c.Decimal(nullable: false, storeType: "money"),
                        AnotherPersonDeath = c.Decimal(nullable: false, storeType: "money"),
                        PassengerDeath = c.Decimal(nullable: false, storeType: "money"),
                        AnotherPassengerDeath = c.Decimal(nullable: false, storeType: "money"),
                        Finance = c.Decimal(nullable: false, storeType: "money"),
                        TpPrime = c.Decimal(nullable: false, storeType: "money"),
                        DriverRisk = c.Decimal(storeType: "money"),
                        CrashSpillDL = c.Decimal(storeType: "money"),
                        BriberyFireDL = c.Decimal(storeType: "money"),
                        ComprehensiveRiskDL = c.Decimal(storeType: "money"),
                        GlassBreakageDL = c.Decimal(storeType: "money"),
                        SpecialEquipmentDL = c.Decimal(precision: 18, scale: 2),
                        SdPrime = c.Decimal(storeType: "money"),
                        VehicleInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.VEHICLE_INFO", t => t.VehicleInfoId, cascadeDelete: true)
                .Index(t => t.VehicleInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("POS.VEHICLE_INFO", "QuotationId", "POS.QUOTATION");
            DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION");
            DropForeignKey("POS.VEHICLE_INFO", "VehicleInfoId", "POS.DRIVERS");
            DropForeignKey("POS.COVERAGES", "VehicleInfoId", "POS.VEHICLE_INFO");
            DropForeignKey("POS.ADDITIONALPRODUCTS", "VehicleInfoId", "POS.VEHICLE_INFO");
            DropForeignKey("POS.ADDITIONALPRODUCTOPTIONS", "ProductId", "POS.ADDITIONALPRODUCTS");
            DropIndex("POS.COVERAGES", new[] { "VehicleInfoId" });
            DropIndex("POS.ADDITIONALPRODUCTOPTIONS", new[] { "ProductId" });
            DropIndex("POS.ADDITIONALPRODUCTS", new[] { "VehicleInfoId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "VehicleInfoId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "QuotationId" });
            DropIndex("POS.DRIVERS", new[] { "QuotationId" });
            DropTable("POS.COVERAGES");
            DropTable("POS.ADDITIONALPRODUCTOPTIONS");
            DropTable("POS.ADDITIONALPRODUCTS");
            DropTable("POS.VEHICLE_INFO");
            DropTable("POS.DRIVERS");
            DropTable("POS.QUOTATION");
        }
    }
}
