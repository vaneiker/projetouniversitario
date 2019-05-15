namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v036 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.DEDUCIBLE_VALUES", "FK_POS.DEDUCIBLE_VALUES_POS.COVERAGES_CoverageId");
            DropColumn("POS.DEDUCIBLE_VALUES", "CoverageId");
        }
        
        public override void Down()
        {
            AddColumn("POS.DEDUCIBLE_VALUES", "CoverageId", c => c.Int(nullable: false));
        }
    }
}
