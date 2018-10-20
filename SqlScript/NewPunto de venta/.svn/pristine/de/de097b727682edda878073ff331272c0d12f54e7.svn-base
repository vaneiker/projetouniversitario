namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0112 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Global.ST_GLOBAL_STATE_PROVINCE",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        Domesticreg_Id = c.Int(nullable: false),
                        State_Prov_Id = c.Int(nullable: false),
                        State_Prov_Desc = c.String(nullable: false, maxLength: 150),
                        State_Prov_Status = c.Boolean(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        hostname = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.Domesticreg_Id, t.State_Prov_Id });
            
        }
        
        public override void Down()
        {
            DropTable("Global.ST_GLOBAL_STATE_PROVINCE");
        }
    }
}
