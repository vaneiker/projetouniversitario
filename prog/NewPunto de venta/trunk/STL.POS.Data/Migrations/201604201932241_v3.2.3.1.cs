namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3231 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Integration.VIRTUAL_OFFICE_INTEGRATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElementType = c.Int(nullable: false),
                        ElementTypeName = c.String(maxLength: 50),
                        PosId = c.String(maxLength: 50),
                        VirtualOfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Integration.VIRTUAL_OFFICE_INTEGRATION");
        }
    }
}
