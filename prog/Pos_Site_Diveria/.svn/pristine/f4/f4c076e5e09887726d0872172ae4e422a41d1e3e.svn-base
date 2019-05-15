namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v037 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "PolicyNumber", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "PolicyNumber");
        }
    }
}
