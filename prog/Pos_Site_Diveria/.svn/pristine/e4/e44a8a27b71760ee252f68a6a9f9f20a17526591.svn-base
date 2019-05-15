namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3015 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "SelectedVehicleTypeName", c => c.String(maxLength: 50));
        }
    }
}
