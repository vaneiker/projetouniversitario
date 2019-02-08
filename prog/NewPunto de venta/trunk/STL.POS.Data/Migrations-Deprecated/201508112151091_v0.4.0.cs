namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v040 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalsPrime", c => c.Decimal(storeType: "money"));
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "IdRaro");
            DropColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "AdditionalsPrime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "IdRaro", c => c.Int(nullable: false));
            DropColumn("POS.ADDITIONAL_PRODUCT_SELECTED", "AdditionalsPrime");
        }
    }
}
