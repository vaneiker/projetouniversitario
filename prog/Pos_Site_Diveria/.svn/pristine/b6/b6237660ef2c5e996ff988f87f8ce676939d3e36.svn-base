using System;
using System.Data.Entity.Migrations;

public partial class v052 : DbMigration
{
    public override void Up()
    {
        AddColumn("POS.PRODUCT_LIMITS", "AdditionalsPrime", c => c.Decimal(storeType: "money"));
    }
    
    public override void Down()
    {
        DropColumn("POS.PRODUCT_LIMITS", "AdditionalsPrime");
    }
}
