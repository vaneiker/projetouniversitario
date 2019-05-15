namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0810 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.USERS", "UserStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("POS.USERS", "UserStatus");
        }
    }
}
