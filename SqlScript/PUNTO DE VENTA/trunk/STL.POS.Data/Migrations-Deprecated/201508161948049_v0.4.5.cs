namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v045 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES", newName: "PRODUCT_DEDUCTIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_ComprehensiveRiskDeductible_Id");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_DriverRiskDeductible_Id");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_FireTheftDeductible_Id");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_GlassBreakageDeductible_Id");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.DEDUCIBLE_VALUES_SpecialEquipmentDeductible_Id");
            DropForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "ComprehensiveRiskDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "DriverRiskDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FireTheftDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "GlassBreakageDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "SpecialEquipmentDeductible_Id", "POS.DEDUCIBLE_VALUES");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "ComprehensiveRiskDeductible_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "DriverRiskDeductible_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "FireTheftDeductible_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "GlassBreakageDeductible_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "SpecialEquipmentDeductible_Id" });
            DropIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            RenameColumn(table: "POS.VEHICLE_PRODUCT", name: "CollisionRolloverDeductible_Id", newName: "Deductible_Id");
            RenameIndex(table: "POS.VEHICLE_PRODUCT", name: "IX_CollisionRolloverDeductible_Id", newName: "IX_Deductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "ComprehensiveRiskDeductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "DriverRiskDeductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "FireTheftDeductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "GlassBreakageDeductible_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "SpecialEquipmentDeductible_Id");
            DropTable("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES");
            DropTable("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES");
            DropTable("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES");
            DropTable("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES");
            DropTable("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES");
        }
        
        public override void Down()
        {
            CreateTable(
                "POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
            
            CreateTable(
                "POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
            
            CreateTable(
                "POS.PRODUCT_FIRE_THEFT_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
            
            CreateTable(
                "POS.PRODUCT_DRIVER_RISK_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
            
            CreateTable(
                "POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id });
            
            AddColumn("POS.VEHICLE_PRODUCT", "SpecialEquipmentDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "GlassBreakageDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "FireTheftDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "DriverRiskDeductible_Id", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "ComprehensiveRiskDeductible_Id", c => c.Int());
            RenameIndex(table: "POS.VEHICLE_PRODUCT", name: "IX_Deductible_Id", newName: "IX_CollisionRolloverDeductible_Id");
            RenameColumn(table: "POS.VEHICLE_PRODUCT", name: "Deductible_Id", newName: "CollisionRolloverDeductible_Id");
            CreateIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "Product_Id");
            CreateIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "Product_Id");
            CreateIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "Product_Id");
            CreateIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "Product_Id");
            CreateIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "DeducibleValues_Id");
            CreateIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "Product_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "SpecialEquipmentDeductible_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "GlassBreakageDeductible_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "FireTheftDeductible_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "DriverRiskDeductible_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "ComprehensiveRiskDeductible_Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "SpecialEquipmentDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "GlassBreakageDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "FireTheftDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "DriverRiskDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "ComprehensiveRiskDeductible_Id", "POS.DEDUCIBLE_VALUES", "Id");
            AddForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES", "Id", cascadeDelete: true);
            AddForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT", "Id", cascadeDelete: true);
            RenameTable(name: "POS.PRODUCT_DEDUCTIBLE_VALUES", newName: "PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES");
        }
    }
}
