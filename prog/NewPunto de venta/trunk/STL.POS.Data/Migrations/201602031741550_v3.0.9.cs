namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v309 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "PrincipalIdentificationNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "PrincipalIdentificationNumber");
        }
    }
}
