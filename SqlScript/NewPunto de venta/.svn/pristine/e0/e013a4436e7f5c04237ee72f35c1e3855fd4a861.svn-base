namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v099 : DbMigration
    {
        public override void Up()
        {
            DropIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            AlterColumn("POS.PERSONS", "WorkCity_Country_Id", c => c.Int());
            AlterColumn("POS.PERSONS", "WorkCity_Domesticreg_Id", c => c.Int());
            AlterColumn("POS.PERSONS", "WorkCity_State_Prov_Id", c => c.Int());
            AlterColumn("POS.PERSONS", "WorkCity_City_Id", c => c.Int());
            CreateIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
        }
        
        public override void Down()
        {
            DropIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            AlterColumn("POS.PERSONS", "WorkCity_City_Id", c => c.Int(nullable: false));
            AlterColumn("POS.PERSONS", "WorkCity_State_Prov_Id", c => c.Int(nullable: false));
            AlterColumn("POS.PERSONS", "WorkCity_Domesticreg_Id", c => c.Int(nullable: false));
            AlterColumn("POS.PERSONS", "WorkCity_Country_Id", c => c.Int(nullable: false));
            CreateIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
        }
    }
}
