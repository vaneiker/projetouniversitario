namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v094 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PRODUCT_LIMITS", "TotalIsc", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.PRODUCT_LIMITS", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("POS.PRODUCT_LIMITS", "TotalDiscount");
            DropColumn("POS.PRODUCT_LIMITS", "TotalIsc");
        }
    }
}
