namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v240 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "AchName", c => c.String(maxLength: 50));
            AddColumn("POS.QUOTATION", "AchAccountHolderGovId", c => c.String(maxLength: 50));
            AddColumn("POS.QUOTATION", "AchBankRoutingNumber", c => c.String(maxLength: 9));
            AddColumn("POS.QUOTATION", "AchType", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "AchNumber", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "AchNumber");
            DropColumn("POS.QUOTATION", "AchType");
            DropColumn("POS.QUOTATION", "AchBankRoutingNumber");
            DropColumn("POS.QUOTATION", "AchAccountHolderGovId");
            DropColumn("POS.QUOTATION", "AchName");
        }
    }
}
