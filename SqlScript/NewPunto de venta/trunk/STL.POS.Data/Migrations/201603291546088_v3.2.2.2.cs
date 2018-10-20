namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3222 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.QUOTATION", "AchBankRoutingNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("POS.QUOTATION", "AchBankRoutingNumber", c => c.String(maxLength: 9));
        }
    }
}
