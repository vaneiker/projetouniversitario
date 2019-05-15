namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v035 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.DEDUCIBLE_VALUES", "CoverageId", "POS.PRODUCT");
            DropIndex("POS.DEDUCIBLE_VALUES", new[] { "CoverageId" });
            CreateTable(
                "POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            CreateTable(
                "POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            CreateTable(
                "POS.PRODUCT_DRIVER_RISK_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            CreateTable(
                "POS.PRODUCT_FIRE_THEFT_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            CreateTable(
                "POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            CreateTable(
                "POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        DeducibleValues_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.DeducibleValues_Id })
                .ForeignKey("POS.PRODUCT", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("POS.DEDUCIBLE_VALUES", t => t.DeducibleValues_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.DeducibleValues_Id);
            
            AddColumn("POS.ADDITIONAL_PRODUCTS", "Description", c => c.String(maxLength: 200));
            AddColumn("POS.DEDUCIBLE_VALUES", "Percentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("POS.ADDITIONAL_PRODUCTS", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropForeignKey("POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES", "DeducibleValues_Id", "POS.DEDUCIBLE_VALUES");
            DropForeignKey("POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES", "Product_Id", "POS.PRODUCT");
            DropIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES", new[] { "Product_Id" });
            DropIndex("POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES", new[] { "DeducibleValues_Id" });
            DropIndex("POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES", new[] { "Product_Id" });
            AlterColumn("POS.ADDITIONAL_PRODUCTS", "Name", c => c.String());
            DropColumn("POS.DEDUCIBLE_VALUES", "Percentage");
            DropColumn("POS.ADDITIONAL_PRODUCTS", "Description");
            DropTable("POS.PRODUCT_SPECIAL_EQUIPMENT_DEDUCIBLES");
            DropTable("POS.PRODUCT_GLASSBREAKAGE_DEDUCIBLES");
            DropTable("POS.PRODUCT_FIRE_THEFT_DEDUCIBLES");
            DropTable("POS.PRODUCT_DRIVER_RISK_DEDUCIBLES");
            DropTable("POS.PRODUCT_COMPREHSIVE_RISK_DEDUCIBLES");
            DropTable("POS.PRODUCT_COLLISION_ROLLOVER_DEDUCIBLES");
            CreateIndex("POS.DEDUCIBLE_VALUES", "CoverageId");
            AddForeignKey("POS.DEDUCIBLE_VALUES", "CoverageId", "POS.PRODUCT", "Id");
        }
    }
}
