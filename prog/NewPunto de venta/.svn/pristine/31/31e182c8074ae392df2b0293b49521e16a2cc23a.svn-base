namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v041 : DbMigration
    {
        public override void Up()
        {
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "TermTypeId" });
            AlterColumn("POS.VEHICLE_PRODUCT", "TermTypeId", c => c.Int());
            CreateIndex("POS.VEHICLE_PRODUCT", "TermTypeId");
        }
        
        public override void Down()
        {
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "TermTypeId" });
            AlterColumn("POS.VEHICLE_PRODUCT", "TermTypeId", c => c.Int(nullable: false));
            CreateIndex("POS.VEHICLE_PRODUCT", "TermTypeId");
        }
    }
}
