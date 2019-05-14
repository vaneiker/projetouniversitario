namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v322 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PRODUCT_TYPE_BROCHURE", "Coberturas", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("POS.PRODUCT_TYPE_BROCHURE", "Coberturas");
        }
    }
}
