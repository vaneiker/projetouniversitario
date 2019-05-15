namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3233 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Integration.VIRTUAL_OFFICE_INTEGRATION", "ElementName", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("Integration.VIRTUAL_OFFICE_INTEGRATION", "ElementName");
        }
    }
}
