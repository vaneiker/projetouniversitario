namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v320 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.COVERAGE_DETAILS_BROCHURE", "Value", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("POS.COVERAGE_DETAILS_BROCHURE", "Value", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
