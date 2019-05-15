namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v046 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PRODUCT", "IsLawProduct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.PRODUCT", "IsLawProduct");
        }
    }
}
