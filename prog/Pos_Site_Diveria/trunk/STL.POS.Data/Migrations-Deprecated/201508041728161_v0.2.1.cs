namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_INFO", "Chassis", c => c.String(maxLength: 50));
            AddColumn("POS.VEHICLE_INFO", "Plate", c => c.String(maxLength: 50));
            AddColumn("POS.VEHICLE_INFO", "Color", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_INFO", "Color");
            DropColumn("POS.VEHICLE_INFO", "Plate");
            DropColumn("POS.VEHICLE_INFO", "Chassis");
        }
    }
}
