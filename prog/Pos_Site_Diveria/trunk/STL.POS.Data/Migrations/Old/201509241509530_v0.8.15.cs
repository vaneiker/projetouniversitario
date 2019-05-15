namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0815 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "AmountPaid", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.QUOTATION", "SendInspectionOnly", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "SendInspectionOnly");
            DropColumn("POS.QUOTATION", "AmountPaid");
        }
    }
}
