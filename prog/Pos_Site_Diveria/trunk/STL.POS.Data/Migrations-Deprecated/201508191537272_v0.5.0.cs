namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v050 : DbMigration
    {
        public override void Up()
        {            
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_CollisionRolloverDeductible_Id");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.COVERAGES_CoverageSelected_Id");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", "POS.ADDITIONAL_PRODUCTS");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProduct_Id", "POS.ADDITIONAL_PRODUCTS");

            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "FK_POS.ADDITIONAL_PRODUCT_SELECTED_POS.ADDITIONAL_PRODUCT_OPTIONS_AdditionalProductOptionSelectedId");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_OPTIONS", "FK_POS.ADDITIONALPRODUCTOPTIONS_POS.ADDITIONALPRODUCTS_AdditionalProductId");

            //DropForeignKey("POS.DEDUCIBLE_VALUES", "FK_POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES_POS.DEDUCIBLE_VALUES_DeducibleValues_Id");
            DropForeignKey("POS.DEDUCIBLE_VALUES", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_CollisionRolloverDeductible_Id");

            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProductOptionSelected_Id", "POS.ADDITIONAL_PRODUCT_OPTIONS");

            //DropForeignKey("POS.PRODUCT_DEDUCTIBLE_VALUES", "Product_Id", "POS.PRODUCT");
            //DropForeignKey("POS.PRODUCT_DEDUCTIBLE_VALUES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Deductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "ProductSelected_Id", "POS.PRODUCT");
            DropIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", new[] { "AdditionalProduct_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "AdditionalProduct_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "AdditionalProductOptionSelected_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "VehicleProduct_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Deductible_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "ProductSelected_Id" });
            DropIndex("POS.PRODUCT_DEDUCTIBLE_VALUES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_DEDUCTIBLE_VALUES", new[] { "DeducibleValues_Id" });
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
            
            AddColumn("POS.ADDITIONAL_PRODUCTS", "IsSelected", c => c.Boolean(nullable: false));
            AddColumn("POS.ADDITIONAL_PRODUCTS", "Prime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "OthersPropertyLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "OnePersonDeathLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "AnotherPersonDeathLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "PassengerDeathLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "AnotherPassengerDeathLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "BailLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "DriverRiskLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "CollisionRolloverLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "FireTheftLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "ComprehensiveRiskLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "GlassBreakageLimits", c => c.String());
            AddColumn("POS.VEHICLE_PRODUCT", "SpecialEquipmentLimits", c => c.String());
            AlterColumn("POS.VEHICLE_PRODUCT", "PercentageToEnsure", c => c.Decimal(precision: 5, scale: 2));
            CreateIndex("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id");
            AddForeignKey("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id", "POS.PRODUCT_LIMITS", "Id");
            DropColumn("POS.VEHICLE_PRODUCT", "SdPrime");
            DropColumn("POS.VEHICLE_PRODUCT", "TpPrime");
            DropColumn("POS.VEHICLE_PRODUCT", "Deductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "ProductSelected_Id");
            DropTable("POS.ADDITIONAL_PRODUCT_OPTIONS");
            DropTable("POS.ADDITIONAL_PRODUCT_SELECTED");
            DropTable("POS.PRODUCT_DEDUCTIBLE_VALUES");
        }
        
        public override void Down()
        {
            CreateTable(
                "POS.PRODUCT_DEDUCTIBLE_VALUES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
          
            
            CreateTable(
                "POS.ADDITIONAL_PRODUCT_SELECTED",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdditionalsPrime = c.Decimal(storeType: "money"),
                        AdditionalProduct_Id = c.Int(nullable: false),
                        AdditionalProductOptionSelected_Id = c.Int(nullable: false),
                        VehicleProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.ADDITIONAL_PRODUCT_OPTIONS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Selected = c.Boolean(nullable: false),
                        AdditionalProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("POS.VEHICLE_PRODUCT", "ProductSelected_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "Deductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "TpPrime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.VEHICLE_PRODUCT", "SdPrime", c => c.Decimal(storeType: "money"));
            DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropForeignKey("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id", "POS.PRODUCT_LIMITS");
            DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCTS", new[] { "ProductLimits_Id" });
            AlterColumn("POS.VEHICLE_PRODUCT", "PercentageToEnsure", c => c.String(maxLength: 5));
            DropColumn("POS.VEHICLE_PRODUCT", "SpecialEquipmentLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "GlassBreakageLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "ComprehensiveRiskLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "FireTheftLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "CollisionRolloverLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "DriverRiskLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "BailLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "AnotherPassengerDeathLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "PassengerDeathLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "AnotherPersonDeathLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "OnePersonDeathLimits");
            DropColumn("POS.VEHICLE_PRODUCT", "OthersPropertyLimits");
            DropColumn("POS.ADDITIONAL_PRODUCTS", "ProductLimits_Id");
            DropColumn("POS.ADDITIONAL_PRODUCTS", "Prime");
            DropColumn("POS.ADDITIONAL_PRODUCTS", "IsSelected");
            DropTable("POS.PRODUCT_LIMITS");
            CreateIndex("POS.PRODUCT_DEDUCTIBLE_VALUES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_DEDUCTIBLE_VALUES", "Product_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "ProductSelected_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "Deductible_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProductOptionSelected_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProduct_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "ProductSelected_Id", "POS.PRODUCT", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Deductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT", "Id");
            AddForeignKey("POS.PRODUCT_DEDUCTIBLE_VALUES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_DEDUCTIBLE_VALUES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            AddForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProductOptionSelected_Id", "POS.ADDITIONAL_PRODUCT_OPTIONS", "Id");
            AddForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalProduct_Id", "POS.ADDITIONAL_PRODUCTS", "Id");
            AddForeignKey("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", "POS.ADDITIONAL_PRODUCTS", "Id", cascadeDelete: true);
        }
    }
}
