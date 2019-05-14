namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v042 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "StartDate", c => c.DateTime());
            AlterColumn("POS.VEHICLE_PRODUCT", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("POS.VEHICLE_PRODUCT", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
