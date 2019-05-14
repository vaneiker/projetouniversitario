namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v099 : DbMigration
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
            
            AddColumn("POS.PERSONS", "WorkCity_Country_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_Domesticreg_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_State_Prov_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_City_Id", c => c.Int());
            AlterColumn("POS.PERSONS", "IsSmoker", c => c.Boolean());
            CreateIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            AddForeignKey("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY", new[] { "Country_Id", "Domesticreg_Id", "State_Prov_Id", "City_Id" });

            AddColumn("POS.PERSONS", "City_Country_Id", c => c.Int());
            AddColumn("POS.PERSONS", "City_Domesticreg_Id", c => c.Int());
            AddColumn("POS.PERSONS", "City_State_Prov_Id", c => c.Int());
            AddColumn("POS.PERSONS", "City_City_Id", c => c.Int());
            CreateIndex("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            AddForeignKey("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY", new[] { "Country_Id", "Domesticreg_Id", "State_Prov_Id", "City_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            AlterColumn("POS.PERSONS", "IsSmoker", c => c.Boolean(nullable: false));
            DropColumn("POS.PERSONS", "WorkCity_City_Id");
            DropColumn("POS.PERSONS", "WorkCity_State_Prov_Id");
            DropColumn("POS.PERSONS", "WorkCity_Domesticreg_Id");
            DropColumn("POS.PERSONS", "WorkCity_Country_Id");

            DropForeignKey("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropIndex("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropColumn("POS.PERSONS", "City_City_Id");
            DropColumn("POS.PERSONS", "City_State_Prov_Id");
            DropColumn("POS.PERSONS", "City_Domesticreg_Id");
            DropColumn("POS.PERSONS", "City_Country_Id");

            DropTable("Global.ST_GLOBAL_STATE_PROVINCE");
        }
    }
}
