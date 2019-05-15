namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0100 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeId", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeName");
            DropColumn("POS.VEHICLE_PRODUCT", "SelectedProductTypeId");
        }
    }
}
