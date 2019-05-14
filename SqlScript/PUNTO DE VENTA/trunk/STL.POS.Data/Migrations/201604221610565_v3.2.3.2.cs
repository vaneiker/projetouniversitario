namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3232 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleYearOld", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleYearOld");
        }
    }
}
