namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v308 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeId", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeName", c => c.String(maxLength: 50));
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedCoverageCoreId", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedCoverageName", c => c.String(maxLength: 100));
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeId");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeName");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageCoreId");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageName");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageName", c => c.String(maxLength: 100));
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageCoreId", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeName", c => c.String(maxLength: 50));
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeId", c => c.Int());
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedCoverageName");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedCoverageCoreId");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeName");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeId");
        }
    }
}
