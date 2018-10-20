namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v032 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "POS.VEHICLE_COVERAGE", newName: "VEHICLE_PRODUCT");
            RenameTable(name: "POS.COVERAGES", newName: "PRODUCT");
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId", "POS.VEHICLE_COVERAGE");
            DropForeignKey("POS.ADDITIONAL_PRODUCTS", "VehicleInfoId", "POS.VEHICLE_COVERAGE");
            DropIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", new[] { "AdditionalProductId" });
            DropIndex("POS.ADDITIONAL_PRODUCTS", new[] { "VehicleInfoId" });
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "VehicleInfoId" });
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_OPTIONS", name: "AdditionalProductId", newName: "AdditionalProduct_Id");
            RenameColumn(table: "POS.VEHICLE_PRODUCT", name: "CoverageSelected_Id", newName: "ProductSelected_Id");
            RenameIndex(table: "POS.VEHICLE_PRODUCT", name: "IX_CoverageSelected_Id", newName: "IX_ProductSelected_Id");
            CreateTable(
                "dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]",
                c => new
                    {
                        VehicleProduct_Id = c.Int(nullable: false),
                        AdditionalProductSelected_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleProduct_Id, t.AdditionalProductSelected_Id })
                .ForeignKey("POS.VEHICLE_PRODUCT", t => t.VehicleProduct_Id, cascadeDelete: true)
                .ForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", t => t.AdditionalProductSelected_Id, cascadeDelete: true)
                .Index(t => t.VehicleProduct_Id)
                .Index(t => t.AdditionalProductSelected_Id);
            
            AddColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.PRODUCT", "Name", c => c.String());
            AlterColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", c => c.Int());
            AlterColumn("POS.VEHICLE_PRODUCT", "TpPrime", c => c.Decimal(storeType: "money"));
            CreateIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id");
            DropColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "Prime");
            DropColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "ProductId");
            DropColumn("POS.ADDITIONAL_PRODUCTS", "VehicleInfoId");
            DropColumn("POS.PRODUCT", "Product");
        }
        
        public override void Down()
        {
            AddColumn("POS.PRODUCT", "Product", c => c.String());
            AddColumn("POS.ADDITIONAL_PRODUCTS", "VehicleInfoId", c => c.Int(nullable: false));
            AddColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "ProductId", c => c.Int(nullable: false));
            AddColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "Prime", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "AdditionalProductSelected_Id", "POS.ADDITIONAL_PRODUCT_SELECTED");
            DropForeignKey("dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropIndex("dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", new[] { "AdditionalProductSelected_Id" });
            DropIndex("dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", new[] { "VehicleProduct_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", new[] { "AdditionalProduct_Id" });
            AlterColumn("POS.VEHICLE_PRODUCT", "TpPrime", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", c => c.Int(nullable: false));
            DropColumn("POS.PRODUCT", "Name");
            DropColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime");
            DropTable("dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]");
            RenameIndex(table: "POS.VEHICLE_PRODUCT", name: "IX_ProductSelected_Id", newName: "IX_CoverageSelected_Id");
            RenameColumn(table: "POS.VEHICLE_PRODUCT", name: "ProductSelected_Id", newName: "CoverageSelected_Id");
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_OPTIONS", name: "AdditionalProduct_Id", newName: "AdditionalProductId");
            CreateIndex("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId");
            CreateIndex("POS.ADDITIONAL_PRODUCTS", "VehicleInfoId");
            CreateIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProductId");
            AddForeignKey("POS.ADDITIONAL_PRODUCTS", "VehicleInfoId", "POS.VEHICLE_COVERAGE", "Id", cascadeDelete: true);
            AddForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId", "POS.VEHICLE_COVERAGE", "Id", cascadeDelete: true);
            RenameTable(name: "POS.PRODUCT", newName: "COVERAGES");
            RenameTable(name: "POS.VEHICLE_PRODUCT", newName: "VEHICLE_COVERAGE");
        }
    }
}
