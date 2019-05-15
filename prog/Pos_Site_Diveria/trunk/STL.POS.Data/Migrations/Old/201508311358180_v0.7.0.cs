namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v070 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PARAMETERS", "Description", c => c.String(maxLength: 4000));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleDescription", c => c.String(maxLength: 500));
            AlterColumn("POS.PRODUCT_LIMITS", "SelectedDeductibleCoreId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("POS.PRODUCT_LIMITS", "SelectedDeductibleCoreId", c => c.Int(nullable: false));
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleDescription");
            DropColumn("POS.PARAMETERS", "Description");
        }
    }
}
