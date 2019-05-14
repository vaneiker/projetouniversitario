namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3010 : DbMigration
    {
        public override void Up()
        {
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServiceType_Id" });
            AlterColumn("POS.COVERAGE_DETAILS", "ServiceType_Id", c => c.Int());
            CreateIndex("POS.COVERAGE_DETAILS", "ServiceType_Id");
        }
        
        public override void Down()
        {
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServiceType_Id" });
            AlterColumn("POS.COVERAGE_DETAILS", "ServiceType_Id", c => c.Int(nullable: false));
            CreateIndex("POS.COVERAGE_DETAILS", "ServiceType_Id");
        }
    }
}
