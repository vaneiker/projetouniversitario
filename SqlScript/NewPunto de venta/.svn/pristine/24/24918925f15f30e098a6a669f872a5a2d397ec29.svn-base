namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.USERS", "AgentId", c => c.Int());
            AlterColumn("POS.COVERAGE_DETAILS_BROCHURE", "Name", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("POS.COVERAGE_DETAILS_BROCHURE", "Name", c => c.String(maxLength: 50));
            DropColumn("POS.USERS", "AgentId");
        }
    }
}
