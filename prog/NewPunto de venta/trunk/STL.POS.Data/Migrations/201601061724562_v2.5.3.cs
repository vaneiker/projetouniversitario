namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v253 : DbMigration
    {
        public override void Up()
        {
            DropColumn("POS.QUOTATION", "PaymentDate");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "PaymentDate", c => c.DateTime());
        }
    }
}
