namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v092 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "ISCPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.QUOTATION", "DiscountPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "TotalIsc", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("POS.VEHICLE_PRODUCT", "ISC");
            DropColumn("POS.VEHICLE_PRODUCT", "ISCPercentage");
            DropColumn("POS.VEHICLE_PRODUCT", "DiscountPercentage");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "DiscountPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "ISCPercentage", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("POS.VEHICLE_PRODUCT", "ISC", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("POS.VEHICLE_PRODUCT", "TotalDiscount");
            DropColumn("POS.VEHICLE_PRODUCT", "TotalIsc");
            DropColumn("POS.QUOTATION", "DiscountPercentage");
            DropColumn("POS.QUOTATION", "ISCPercentage");
        }
    }
}
