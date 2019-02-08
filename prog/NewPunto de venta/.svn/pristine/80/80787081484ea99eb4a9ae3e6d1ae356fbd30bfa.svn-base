namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v064 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleTypeCoreId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleTypeCoreId");
        }
    }
}
