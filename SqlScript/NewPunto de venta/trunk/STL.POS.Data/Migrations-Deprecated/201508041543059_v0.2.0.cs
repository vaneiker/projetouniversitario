namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.ADDITIONALPRODUCTOPTIONS", "ProductId", "POS.ADDITIONALPRODUCTS");
            DropIndex("POS.ADDITIONALPRODUCTOPTIONS", new[] { "ProductId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "VehicleInfoId" });
            RenameColumn(table: "POS.VEHICLE_INFO", name: "VehicleInfoId", newName: "DriverId");
            AddColumn("POS.ADDITIONALPRODUCTOPTIONS", "AdditionalProductId", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_INFO", "UsageId", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_INFO", "StoredId", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_INFO", "Pricing", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("POS.VEHICLE_INFO", "DriverId", c => c.Int(nullable: false));
            CreateIndex("POS.ADDITIONALPRODUCTOPTIONS", "AdditionalProductId");
            CreateIndex("POS.VEHICLE_INFO", new[] { "MakeId", "ModelId", "VersionId" });
            CreateIndex("POS.VEHICLE_INFO", "DriverId");
            CreateIndex("POS.VEHICLE_INFO", "UsageId");
            CreateIndex("POS.VEHICLE_INFO", "StoredId");
            AddForeignKey("POS.VEHICLE_INFO", "StoredId", "Global.ST_VEHICLE_STORED", "Stored_Id");
            AddForeignKey("POS.VEHICLE_INFO", "UsageId", "Global.ST_VEHICLE_USAGE", "Usage_Id");
            AddForeignKey("POS.VEHICLE_INFO", new[] { "MakeId", "ModelId", "VersionId" }, "Global.ST_VEHICLE_VERSION", new[] { "Make_Id", "Model_Id", "Version_Id" });
            AddForeignKey("POS.ADDITIONALPRODUCTOPTIONS", "AdditionalProductId", "POS.ADDITIONALPRODUCTS", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("POS.ADDITIONALPRODUCTOPTIONS", "AdditionalProductId", "POS.ADDITIONALPRODUCTS");
            DropForeignKey("POS.VEHICLE_INFO", new[] { "MakeId", "ModelId", "VersionId" }, "Global.ST_VEHICLE_VERSION");
            DropForeignKey("POS.VEHICLE_INFO", "UsageId", "Global.ST_VEHICLE_USAGE");
            DropForeignKey("POS.VEHICLE_INFO", "StoredId", "Global.ST_VEHICLE_STORED");
            DropIndex("POS.VEHICLE_INFO", new[] { "StoredId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "UsageId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "DriverId" });
            DropIndex("POS.VEHICLE_INFO", new[] { "MakeId", "ModelId", "VersionId" });
            DropIndex("POS.ADDITIONALPRODUCTOPTIONS", new[] { "AdditionalProductId" });
            AlterColumn("POS.VEHICLE_INFO", "DriverId", c => c.Int());
            DropColumn("POS.VEHICLE_INFO", "Pricing");
            DropColumn("POS.VEHICLE_INFO", "StoredId");
            DropColumn("POS.VEHICLE_INFO", "UsageId");
            DropColumn("POS.ADDITIONALPRODUCTOPTIONS", "AdditionalProductId");
            RenameColumn(table: "POS.VEHICLE_INFO", name: "DriverId", newName: "VehicleInfoId");
            CreateIndex("POS.VEHICLE_INFO", "VehicleInfoId");
            CreateIndex("POS.ADDITIONALPRODUCTOPTIONS", "ProductId");
            AddForeignKey("POS.ADDITIONALPRODUCTOPTIONS", "ProductId", "POS.ADDITIONALPRODUCTS", "Id", cascadeDelete: true);
        }
    }
}
