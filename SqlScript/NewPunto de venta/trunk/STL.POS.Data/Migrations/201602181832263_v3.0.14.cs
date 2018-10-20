namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3014 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PRODUCT_TYPE_BROCHURE", "Elegibilidad", c => c.String());
            AddColumn("POS.PRODUCT_TYPE_BROCHURE", "Deducible", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("POS.PRODUCT_TYPE_BROCHURE", "Deducible");
            DropColumn("POS.PRODUCT_TYPE_BROCHURE", "Elegibilidad");
        }
    }
}
