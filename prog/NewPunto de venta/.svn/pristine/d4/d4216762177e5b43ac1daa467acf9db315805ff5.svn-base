namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v302 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.BUSINESS_LINE", "Path", c => c.String(maxLength: 200));
            AlterColumn("POS.BUSINESS_LINE", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("POS.BUSINESS_LINE", "Name", c => c.String());
            DropColumn("POS.BUSINESS_LINE", "Path");
        }
    }
}
