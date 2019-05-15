namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v091 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "CardnetLastResponseCode", c => c.String(maxLength: 10));
            AddColumn("POS.QUOTATION", "CardnetLastResponseMessage", c => c.String(maxLength: 100));
            AddColumn("POS.QUOTATION", "CardnetAuthorizationCode", c => c.String(maxLength: 10));
            AddColumn("POS.QUOTATION", "CardnetPaymentStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "CardnetPaymentStatus");
            DropColumn("POS.QUOTATION", "CardnetAuthorizationCode");
            DropColumn("POS.QUOTATION", "CardnetLastResponseMessage");
            DropColumn("POS.QUOTATION", "CardnetLastResponseCode");
        }
    }
}
