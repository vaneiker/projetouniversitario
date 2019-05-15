namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v097 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PERSONS", "Complication", c => c.Boolean(nullable: false));
            AddColumn("POS.PERSONS", "Transplant", c => c.Boolean(nullable: false));
            AddColumn("POS.QUOTATION_SALUD", "PlanType", c => c.String(maxLength: 50));
            AddColumn("POS.QUOTATION_SALUD", "Plan", c => c.String(maxLength: 50));
            AddColumn("POS.QUOTATION_SALUD", "Deductible", c => c.Decimal(storeType: "money"));
            AlterColumn("POS.PERSONS", "Weight", c => c.Decimal(precision: 5, scale: 2));
            AlterColumn("POS.PERSONS", "Height", c => c.Decimal(precision: 5, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("POS.PERSONS", "Height", c => c.Decimal(nullable: true, precision: 5, scale: 2));
            AlterColumn("POS.PERSONS", "Weight", c => c.Decimal(nullable: true, precision: 5, scale: 2));
            DropColumn("POS.QUOTATION_SALUD", "Deductible");
            DropColumn("POS.QUOTATION_SALUD", "Plan");
            DropColumn("POS.QUOTATION_SALUD", "PlanType");
            DropColumn("POS.PERSONS", "Transplant");
            DropColumn("POS.PERSONS", "Complication");
        }
    }
}
