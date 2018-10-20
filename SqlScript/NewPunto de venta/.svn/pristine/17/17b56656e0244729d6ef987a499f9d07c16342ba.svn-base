namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v033 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", newSchema: "POS");
        }
        
        public override void Down()
        {
            MoveTable(name: "POS.[POS.VEHICLE_PRODUCT_ADDITIONAL_PRODUCT]", newSchema: "dbo");
        }
    }
}
