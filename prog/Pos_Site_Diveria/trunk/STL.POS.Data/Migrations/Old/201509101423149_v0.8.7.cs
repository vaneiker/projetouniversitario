namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v087 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.QUOTATION", "PaymentFrequencyId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("POS.QUOTATION", "PaymentFrequencyId", c => c.Int(nullable: false));
        }
    }
}
