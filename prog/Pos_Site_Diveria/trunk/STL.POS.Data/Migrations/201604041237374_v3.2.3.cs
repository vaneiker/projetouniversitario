namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v323 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.CURRENCIES", "IsoCode", c => c.String(maxLength: 5));
            AddColumn("POS.USERS", "UserType", c => c.Int(nullable: false));
            AddColumn("POS.USERS", "VirtualOfficeId", c => c.Int());
            AddColumn("POS.USERS", "Suscriptor_Id", c => c.Int());
            CreateIndex("POS.USERS", "Suscriptor_Id");
            AddForeignKey("POS.USERS", "Suscriptor_Id", "POS.USERS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("POS.USERS", "Suscriptor_Id", "POS.USERS");
            DropIndex("POS.USERS", new[] { "Suscriptor_Id" });
            DropColumn("POS.USERS", "Suscriptor_Id");
            DropColumn("POS.USERS", "VirtualOfficeId");
            DropColumn("POS.USERS", "UserType");
            DropColumn("POS.CURRENCIES", "IsoCode");
        }
    }
}
