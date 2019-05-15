namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v088 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 255),
                        Salt = c.String(maxLength: 500),
                        PasswordEncoded = c.String(maxLength: 500),
                        UserOrigin = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastDateModified = c.DateTime(),
                        LastLogin = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("POS.QUOTATION", "User_Id", c => c.Int(nullable: false));
            CreateIndex("POS.QUOTATION", "User_Id");
            AddForeignKey("POS.QUOTATION", "User_Id", "POS.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("POS.QUOTATION", "User_Id", "POS.Users");
            DropIndex("POS.QUOTATION", new[] { "User_Id" });
            DropColumn("POS.QUOTATION", "User_Id");
            DropTable("POS.Users");
        }
    }
}
