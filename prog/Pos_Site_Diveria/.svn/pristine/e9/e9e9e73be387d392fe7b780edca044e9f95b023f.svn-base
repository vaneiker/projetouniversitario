namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.BENEFITS_BROCHURE", "Basic", c => c.Boolean(nullable: false));
            AddColumn("POS.BENEFITS_BROCHURE", "Ultra", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.BENEFITS_BROCHURE", "Ultra");
            DropColumn("POS.BENEFITS_BROCHURE", "Basic");
        }
    }
}
