namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v303 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.BUSINESS_LINE", "CoreId", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "BusinessLine_Id", c => c.Int());
            AlterColumn("POS.QUOTATION", "ProductNumber", c => c.String());
            CreateIndex("POS.QUOTATION", "BusinessLine_Id");
            AddForeignKey("POS.QUOTATION", "BusinessLine_Id", "POS.BUSINESS_LINE", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("POS.QUOTATION", "BusinessLine_Id", "POS.BUSINESS_LINE");
            DropIndex("POS.QUOTATION", new[] { "BusinessLine_Id" });
            AlterColumn("POS.QUOTATION", "ProductNumber", c => c.String(maxLength: 2));
            DropColumn("POS.QUOTATION", "BusinessLine_Id");
            DropColumn("POS.BUSINESS_LINE", "CoreId");
        }
    }
}
