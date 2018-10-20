namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0814 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "DiscountPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleTypeName", c => c.String(maxLength: 60));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleMakeName", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleMakeName");
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleTypeName");
            DropColumn("POS.VEHICLE_PRODUCT", "DiscountPercentage");
        }
    }
}
