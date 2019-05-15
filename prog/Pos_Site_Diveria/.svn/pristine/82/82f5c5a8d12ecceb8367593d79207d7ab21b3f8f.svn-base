namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v044 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.DRIVERS", "City_Country_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_Domesticreg_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_State_Prov_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_City_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "Nationality_Global_Country_Id", c => c.Int());
            CreateIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            CreateIndex("POS.DRIVERS", "Nationality_Global_Country_Id");
            AddForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY", new[] { "Country_Id", "Domesticreg_Id", "State_Prov_Id", "City_Id" });
            AddForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY", "Global_Country_Id");
            DropColumn("POS.DRIVERS", "CityId");
            DropColumn("POS.DRIVERS", "Nationality");
        }
        
        public override void Down()
        {
            AddColumn("POS.DRIVERS", "Nationality", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "CityId", c => c.Int(nullable: false));
            DropForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropIndex("POS.DRIVERS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropColumn("POS.DRIVERS", "Nationality_Global_Country_Id");
            DropColumn("POS.DRIVERS", "City_City_Id");
            DropColumn("POS.DRIVERS", "City_State_Prov_Id");
            DropColumn("POS.DRIVERS", "City_Domesticreg_Id");
            DropColumn("POS.DRIVERS", "City_Country_Id");
        }
    }
}
