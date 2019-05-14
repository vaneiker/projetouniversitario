namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v030 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "POS.ADDITIONALPRODUCTOPTIONS", newName: "ADDITIONAL_PRODUCT_OPTIONS");
            RenameTable(name: "POS.VEHICLE_INFO", newName: "VEHICLE_COVERAGE");
            DropForeignKey("POS.ADDITIONALPRODUCTS", "VehicleInfoId", "POS.VEHICLE_INFO");
            DropForeignKey("POS.COVERAGES", "VehicleInfoId", "POS.VEHICLE_INFO");
            DropIndex("POS.COVERAGES", new[] { "VehicleInfoId" });
            CreateTable(
                "POS.ADDITIONAL_PRODUCT_SELECTED",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdditionalProductId = c.Int(nullable: false),
                        Prime = c.Decimal(nullable: false, storeType: "money"),
                        AdditionalProductOptionSelectedId = c.Int(nullable: false),
                        VehicleInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.ADDITIONALPRODUCTS", t => t.AdditionalProductId)
                .ForeignKey("POS.ADDITIONAL_PRODUCT_OPTIONS", t => t.AdditionalProductOptionSelectedId)
                .ForeignKey("POS.VEHICLE_COVERAGE", t => t.VehicleInfoId, cascadeDelete: true)
                .Index(t => t.AdditionalProductId)
                .Index(t => t.AdditionalProductOptionSelectedId)
                .Index(t => t.VehicleInfoId);
            
            CreateTable(
                "POS.DEDUCIBLE_VALUES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        CoverageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.COVERAGES", t => t.CoverageId)
                .Index(t => t.CoverageId);
            
            CreateTable(
                "POS.TERM_TYPES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        TimesPanInMonths = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("POS.COVERAGES", "RefCoreId", c => c.Int(nullable: false));
            AddColumn("POS.COVERAGES", "DriverRiskLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "CollisionRolloverLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "FireTheftLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "ComprehensiveRiskLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "GlassBreakageLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "SpecialEquipmentLimit", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "PercentageToEnsure", c => c.Decimal(precision: 5, scale: 2));
            AddColumn("POS.QUOTATION", "ProductNumber", c => c.String(maxLength: 2));
            AddColumn("POS.QUOTATION", "QuotationDailyNumber", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_COVERAGE", "TermTypeId", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_COVERAGE", "VehiclePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_COVERAGE", "EnsuredAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_COVERAGE", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("POS.VEHICLE_COVERAGE", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("POS.VEHICLE_COVERAGE", "SdPrime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.VEHICLE_COVERAGE", "TpPrime", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("POS.VEHICLE_COVERAGE", "PercentageToEnsure", c => c.String(maxLength: 5));
            AddColumn("POS.VEHICLE_COVERAGE", "CollisionRolloverDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "ComprehensiveRiskDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "CoverageSelected_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "DriverRiskDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "FireTheftDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "GlassBreakageDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_COVERAGE", "SpecialEquipmentDeductible_Id", c => c.Int());
            CreateIndex("POS.VEHICLE_COVERAGE", "TermTypeId");
            CreateIndex("POS.VEHICLE_COVERAGE", "CollisionRolloverDeductible_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "ComprehensiveRiskDeductible_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "CoverageSelected_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "DriverRiskDeductible_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "FireTheftDeductible_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "GlassBreakageDeductible_Id");
            CreateIndex("POS.VEHICLE_COVERAGE", "SpecialEquipmentDeductible_Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "CollisionRolloverDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "ComprehensiveRiskDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "CoverageSelected_Id", "POS.COVERAGES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "DriverRiskDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "FireTheftDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "GlassBreakageDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "SpecialEquipmentDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_COVERAGE", "TermTypeId", "POS.TERM_TYPES", "Id");
            DropColumn("POS.COVERAGES", "Selected");
            DropColumn("POS.COVERAGES", "TpPrime");
            DropColumn("POS.COVERAGES", "DriverRisk");
            DropColumn("POS.COVERAGES", "CrashSpillDL");
            DropColumn("POS.COVERAGES", "BriberyFireDL");
            DropColumn("POS.COVERAGES", "ComprehensiveRiskDL");
            DropColumn("POS.COVERAGES", "GlassBreakageDL");
            DropColumn("POS.COVERAGES", "SpecialEquipmentDL");
            DropColumn("POS.COVERAGES", "SdPrime");
            DropColumn("POS.COVERAGES", "VehicleInfoId");
            DropColumn("POS.VEHICLE_COVERAGE", "Pricing");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_COVERAGE", "Pricing", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("POS.COVERAGES", "VehicleInfoId", c => c.Int(nullable: false));
            AddColumn("POS.COVERAGES", "SdPrime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "SpecialEquipmentDL", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.COVERAGES", "GlassBreakageDL", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "ComprehensiveRiskDL", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "BriberyFireDL", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "CrashSpillDL", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "DriverRisk", c => c.Decimal(storeType: "money"));
            AddColumn("POS.COVERAGES", "TpPrime", c => c.Decimal(nullable: false, storeType: "money"));
            AddColumn("POS.COVERAGES", "Selected", c => c.Boolean(nullable: false));
            DropForeignKey("POS.VEHICLE_COVERAGE", "TermTypeId", "POS.TERM_TYPES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "SpecialEquipmentDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "GlassBreakageDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "FireTheftDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "DriverRiskDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "CoverageSelected_Id", "POS.COVERAGES");
            DropForeignKey("POS.DEDUCIBLE_VALUES", "CoverageId", "POS.COVERAGES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "ComprehensiveRiskDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_COVERAGE", "CollisionRolloverDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId", "POS.VEHICLE_COVERAGE");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProductOptionSelectedId", "POS.ADDITIONAL_PRODUCT_OPTIONS");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProductId", "POS.ADDITIONALPRODUCTS");
            DropIndex("POS.DEDUCIBLE_VALUES", new[] { "CoverageId" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "VehicleInfoId" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "AdditionalProductOptionSelectedId" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "AdditionalProductId" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "SpecialEquipmentDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "GlassBreakageDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "FireTheftDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "DriverRiskDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "CoverageSelected_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "ComprehensiveRiskDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "CollisionRolloverDeductible_Id" });
            DropIndex("POS.VEHICLE_COVERAGE", new[] { "TermTypeId" });
            DropColumn("POS.VEHICLE_COVERAGE", "SpecialEquipmentDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "GlassBreakageDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "FireTheftDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "DriverRiskDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "CoverageSelected_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "ComprehensiveRiskDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "CollisionRolloverDeductible_Id");
            DropColumn("POS.VEHICLE_COVERAGE", "PercentageToEnsure");
            DropColumn("POS.VEHICLE_COVERAGE", "TpPrime");
            DropColumn("POS.VEHICLE_COVERAGE", "SdPrime");
            DropColumn("POS.VEHICLE_COVERAGE", "EndDate");
            DropColumn("POS.VEHICLE_COVERAGE", "StartDate");
            DropColumn("POS.VEHICLE_COVERAGE", "EnsuredAmount");
            DropColumn("POS.VEHICLE_COVERAGE", "VehiclePrice");
            DropColumn("POS.VEHICLE_COVERAGE", "TermTypeId");
            DropColumn("POS.QUOTATION", "QuotationDailyNumber");
            DropColumn("POS.QUOTATION", "ProductNumber");
            DropColumn("POS.COVERAGES", "PercentageToEnsure");
            DropColumn("POS.COVERAGES", "SpecialEquipmentLimit");
            DropColumn("POS.COVERAGES", "GlassBreakageLimit");
            DropColumn("POS.COVERAGES", "ComprehensiveRiskLimit");
            DropColumn("POS.COVERAGES", "FireTheftLimit");
            DropColumn("POS.COVERAGES", "CollisionRolloverLimit");
            DropColumn("POS.COVERAGES", "DriverRiskLimit");
            DropColumn("POS.COVERAGES", "RefCoreId");
            DropTable("POS.TERM_TYPES");
            DropTable("POS.DEDUCIBLE_VALUES");
            DropTable("POS.ADDITIONAL_PRODUCT_SELECTED");
            CreateIndex("POS.COVERAGES", "VehicleInfoId");
            AddForeignKey("POS.COVERAGES", "VehicleInfoId", "POS.VEHICLE_INFO", "Id", cascadeDelete: true);
            AddForeignKey("POS.ADDITIONALPRODUCTS", "VehicleInfoId", "POS.VEHICLE_INFO", "Id", cascadeDelete: true);
            RenameTable(name: "POS.VEHICLE_COVERAGE", newName: "VEHICLE_INFO");
            RenameTable(name: "POS.ADDITIONAL_PRODUCT_OPTIONS", newName: "ADDITIONALPRODUCTOPTIONS");
        }
    }
}
