namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "LastStepVisited", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "LastStepVisited");
        }
    }
}
