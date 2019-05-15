namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v083 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "UsageName", c => c.String(maxLength: 50));
            AddColumn("POS.VEHICLE_PRODUCT", "StoreName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "StoreName");
            DropColumn("POS.VEHICLE_PRODUCT", "UsageName");
        }
    }
}
