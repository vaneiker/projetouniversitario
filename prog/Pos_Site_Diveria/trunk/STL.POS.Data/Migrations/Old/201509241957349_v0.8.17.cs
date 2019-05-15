namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0817 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "ClientCoreIdNumber", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "ClientCoreIdNumber");
        }
    }
}
