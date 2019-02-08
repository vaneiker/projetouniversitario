namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v280 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PERSONS", "Prime", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("POS.PERSONS", "Prime");
        }
    }
}
