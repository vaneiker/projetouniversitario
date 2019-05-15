namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v065 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
            AlterColumn("POS.PRODUCT_LIMITS", "VehicleProduct_Id", c => c.Int(nullable: false));
            CreateIndex("POS.PRODUCT_LIMITS", "VehicleProduct_Id");
            AddForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
            AlterColumn("POS.PRODUCT_LIMITS", "VehicleProduct_Id", c => c.Int());
            CreateIndex("POS.PRODUCT_LIMITS", "VehicleProduct_Id");
            AddForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT", "Id");
        }
    }
}
