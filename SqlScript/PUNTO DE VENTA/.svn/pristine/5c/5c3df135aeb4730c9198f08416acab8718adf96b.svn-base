namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v082 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PRODUCT_LIMITS", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.PRODUCT_LIMITS", "ISC", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.PRODUCT_LIMITS", "ISCPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.QUOTATION", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.QUOTATION", "TotalISC", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "ISC", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "ISCPercentage", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "ISCPercentage");
            DropColumn("POS.VEHICLE_PRODUCT", "ISC");
            DropColumn("POS.VEHICLE_PRODUCT", "TotalPrime");
            DropColumn("POS.QUOTATION", "TotalISC");
            DropColumn("POS.QUOTATION", "TotalPrime");
            DropColumn("POS.PRODUCT_LIMITS", "ISCPercentage");
            DropColumn("POS.PRODUCT_LIMITS", "ISC");
            DropColumn("POS.PRODUCT_LIMITS", "TotalPrime");
        }
    }
}
