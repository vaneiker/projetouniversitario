namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v071 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "Year", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "Year");
        }
    }
}
