namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0813 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageName", c => c.String(maxLength: 100));
            AlterColumn("POS.VEHICLE_PRODUCT", "SelectedProductName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "SelectedProductName", c => c.String());
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductUsageName");
        }
    }
}
