namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v034 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropForeignKey("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "AdditionalProductSelected_Id", "POS.ADDITIONAL_PRODUCT_SELECTED");
            DropIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", new[] { "AdditionalProduct_Id" });
            DropIndex("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", new[] { "VehicleProduct_Id" });
            DropIndex("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", new[] { "AdditionalProductSelected_Id" });
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "AdditionalProductId", newName: "AdditionalProduct_Id");
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "AdditionalProductOptionSelectedId", newName: "AdditionalProductOptionSelected_Id");
            RenameIndex(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "IX_AdditionalProductId", newName: "IX_AdditionalProduct_Id");
            RenameIndex(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "IX_AdditionalProductOptionSelectedId", newName: "IX_AdditionalProductOptionSelected_Id");
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "IdRaro", c => c.Int(nullable: false));
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id", c => c.Int(nullable: false));
            AlterColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", c => c.Int(nullable: false));
            AlterColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime", c => c.Decimal(storeType: "money"));
            CreateIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id");
            AddForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT", "Id");
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "Prime");
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId");
            DropTable("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]");
        }
        
        public override void Down()
        {
            CreateTable(
                "POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]",
                c => new
                    {
                        VehicleProduct_Id = c.Int(nullable: false),
                        AdditionalProductSelected_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VehicleProduct_Id, t.AdditionalProductSelected_Id });
            
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleInfoId", c => c.Int(nullable: false));
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "Prime", c => c.Decimal(nullable: false, storeType: "money"));
            DropForeignKey("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropIndex("POS.ADDITIONAL_PRODUCT_SELECTED", new[] { "VehicleProduct_Id" });
            DropIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", new[] { "AdditionalProduct_Id" });
            AlterColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id", c => c.Int());
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "VehicleProduct_Id");
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "IdRaro");
            RenameIndex(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "IX_AdditionalProductOptionSelected_Id", newName: "IX_AdditionalProductOptionSelectedId");
            RenameIndex(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "IX_AdditionalProduct_Id", newName: "IX_AdditionalProductId");
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "AdditionalProductOptionSelected_Id", newName: "AdditionalProductOptionSelectedId");
            RenameColumn(table: "POS.ADDITIONAL_PRODUCT_SELECTED", name: "AdditionalProduct_Id", newName: "AdditionalProductId");
            CreateIndex("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "AdditionalProductSelected_Id");
            CreateIndex("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "VehicleProduct_Id");
            CreateIndex("POS.ADDITIONAL_PRODUCT_OPTIONS", "AdditionalProduct_Id");
            AddForeignKey("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "AdditionalProductSelected_Id", "POS.ADDITIONAL_PRODUCT_SELECTED", "Id", cascadeDelete: true);
            AddForeignKey("POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT", "Id", cascadeDelete: true);
        }
    }
}
