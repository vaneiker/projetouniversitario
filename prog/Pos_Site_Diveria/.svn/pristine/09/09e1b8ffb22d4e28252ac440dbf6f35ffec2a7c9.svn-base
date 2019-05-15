namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v090 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("POS.QUOTATION", "AmountPaid");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "AmountPaid", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("POS.QUOTATION", "TotalDiscount");
        }
    }
}
