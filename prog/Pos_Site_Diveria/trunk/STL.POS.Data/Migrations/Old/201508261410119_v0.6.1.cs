namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v061 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.PARAMETERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FriendlyName = c.String(maxLength: 100),
                        Value = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("POS.PARAMETERS");
        }
    }
}
