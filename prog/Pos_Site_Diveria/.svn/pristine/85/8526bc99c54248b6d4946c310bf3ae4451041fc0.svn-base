namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "Created", c => c.DateTime(nullable: false));
            AddColumn("POS.QUOTATION", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "LastModified");
            DropColumn("POS.QUOTATION", "Created");
        }
    }
}
