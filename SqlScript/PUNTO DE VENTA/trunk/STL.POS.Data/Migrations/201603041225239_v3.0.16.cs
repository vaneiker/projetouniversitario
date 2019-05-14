namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "CurrencySymbol", c => c.String(maxLength: 10));
            AddColumn("POS.QUOTATION", "Currency_Id", c => c.Int(nullable: false));
            CreateIndex("POS.QUOTATION", "Currency_Id");
            AddForeignKey("POS.QUOTATION", "Currency_Id", "POS.CURRENCIES", "Id", cascadeDelete: true);
            DropColumn("POS.QUOTATION", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "Currency", c => c.String(maxLength: 10));
            DropForeignKey("POS.QUOTATION", "Currency_Id", "POS.CURRENCIES");
            DropIndex("POS.QUOTATION", new[] { "Currency_Id" });
            DropColumn("POS.QUOTATION", "Currency_Id");
            DropColumn("POS.QUOTATION", "CurrencySymbol");
        }
    }
}
