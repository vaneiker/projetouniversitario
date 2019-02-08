namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v062 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.COVERAGE_DETAILS", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.COVERAGE_DETAILS", "IsSelected");
        }
    }
}
