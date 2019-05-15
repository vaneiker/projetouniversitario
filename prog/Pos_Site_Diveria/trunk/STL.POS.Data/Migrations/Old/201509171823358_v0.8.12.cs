namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0812 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageCoreId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageCoreId");
        }
    }
}
