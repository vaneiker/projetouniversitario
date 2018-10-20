namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v063 : DbMigration
    {
        public override void Up()
        {
            DropIndex("POS.COVERAGE_DETAILS", new[] { "SelfDamagesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServicesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ThirdPartyToProductLimits" });
            AlterColumn("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits", c => c.Int());
            AlterColumn("POS.COVERAGE_DETAILS", "ServicesToProductLimits", c => c.Int());
            AlterColumn("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits", c => c.Int());
            CreateIndex("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits");
            CreateIndex("POS.COVERAGE_DETAILS", "ServicesToProductLimits");
            CreateIndex("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits");
        }
        
        public override void Down()
        {
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ThirdPartyToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServicesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "SelfDamagesToProductLimits" });
            AlterColumn("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits", c => c.Int(nullable: false));
            AlterColumn("POS.COVERAGE_DETAILS", "ServicesToProductLimits", c => c.Int(nullable: false));
            AlterColumn("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits", c => c.Int(nullable: false));
            CreateIndex("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits");
            CreateIndex("POS.COVERAGE_DETAILS", "ServicesToProductLimits");
            CreateIndex("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits");
        }
    }
}
