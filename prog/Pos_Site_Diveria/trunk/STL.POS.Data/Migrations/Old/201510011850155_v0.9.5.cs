namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v095 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.PRODUCT_LIMITS", "TotalPrime", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.PRODUCT_LIMITS", "TotalIsc", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.PRODUCT_LIMITS", "TotalDiscount", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.QUOTATION", "TotalPrime", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.QUOTATION", "TotalISC", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.QUOTATION", "TotalDiscount", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalPrime", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalIsc", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalDiscount", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalIsc", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.VEHICLE_PRODUCT", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.QUOTATION", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.QUOTATION", "TotalISC", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.QUOTATION", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.PRODUCT_LIMITS", "TotalDiscount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.PRODUCT_LIMITS", "TotalIsc", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("POS.PRODUCT_LIMITS", "TotalPrime", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
