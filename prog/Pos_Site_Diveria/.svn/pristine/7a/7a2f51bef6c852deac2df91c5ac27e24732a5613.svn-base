namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v098 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PERSONS", "PartnerName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("POS.PERSONS", "PartnerName");
        }
    }
}
