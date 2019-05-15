namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v084 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "PaymentWay", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "PaymentWay");
        }
    }
}
