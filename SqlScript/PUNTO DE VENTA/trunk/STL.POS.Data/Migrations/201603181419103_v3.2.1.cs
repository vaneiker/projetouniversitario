namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v321 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.ProductTypeBrochureCurrencies", "ProductTypeBrochure_Id", "POS.PRODUCT_TYPE_BROCHURE");
            DropForeignKey("POS.ProductTypeBrochureCurrencies", "Currency_Id", "POS.CURRENCIES");
            DropIndex("POS.ProductTypeBrochureCurrencies", new[] { "ProductTypeBrochure_Id" });
            DropIndex("POS.ProductTypeBrochureCurrencies", new[] { "Currency_Id" });
            DropTable("POS.ProductTypeBrochureCurrencies");
        }
        
        public override void Down()
        {
            CreateTable(
                "POS.ProductTypeBrochureCurrencies",
                c => new
                    {
                        ProductTypeBrochure_Id = c.Int(nullable: false),
                        Currency_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductTypeBrochure_Id, t.Currency_Id });
            
            CreateIndex("POS.ProductTypeBrochureCurrencies", "Currency_Id");
            CreateIndex("POS.ProductTypeBrochureCurrencies", "ProductTypeBrochure_Id");
            AddForeignKey("POS.ProductTypeBrochureCurrencies", "Currency_Id", "POS.CURRENCIES", "Id", cascadeDelete: true);
            AddForeignKey("POS.ProductTypeBrochureCurrencies", "ProductTypeBrochure_Id", "POS.PRODUCT_TYPE_BROCHURE", "Id", cascadeDelete: true);
        }
    }
}
