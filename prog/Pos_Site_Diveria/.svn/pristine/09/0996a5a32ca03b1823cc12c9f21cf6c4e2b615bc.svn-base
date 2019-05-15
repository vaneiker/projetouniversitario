namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v300 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "PrincipalFullName", c => c.String(maxLength: 200));
            AddColumn("POS.QUOTATION", "Currency", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "Currency");
            DropColumn("POS.QUOTATION", "PrincipalFullName");
        }
    }
}
