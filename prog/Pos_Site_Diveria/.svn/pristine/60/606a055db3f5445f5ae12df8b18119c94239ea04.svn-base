namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v031 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "POS.ADDITIONALPRODUCTS", newName: "ADDITIONAL_PRODUCTS");
        }
        
        public override void Down()
        {
            RenameTable(name: "POS.ADDITIONAL_PRODUCTS", newName: "ADDITIONALPRODUCTS");
        }
    }
}
