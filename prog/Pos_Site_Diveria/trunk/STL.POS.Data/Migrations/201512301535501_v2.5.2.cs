namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v252 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.DRIVERS", "IdentificationType", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("POS.DRIVERS", "IdentificationType");
        }
    }
}
