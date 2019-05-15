namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v089 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.USERS", "ChangePasswordToken", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("POS.USERS", "ChangePasswordToken");
        }
    }
}
