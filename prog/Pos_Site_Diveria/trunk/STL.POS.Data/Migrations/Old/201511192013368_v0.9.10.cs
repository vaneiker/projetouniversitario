namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0910 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.PERSONS", "IsStudent", c => c.Boolean());
            AddColumn("POS.PERSONS", "IsHighPressure", c => c.Boolean());
            AddColumn("POS.PERSONS", "WorkNationality_Global_Country_Id", c => c.Int());
            CreateIndex("POS.PERSONS", "WorkNationality_Global_Country_Id");
            AddForeignKey("POS.PERSONS", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY", "Global_Country_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("POS.PERSONS", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropIndex("POS.PERSONS", new[] { "WorkNationality_Global_Country_Id" });
            DropColumn("POS.PERSONS", "WorkNationality_Global_Country_Id");
            DropColumn("POS.PERSONS", "IsHighPressure");
            DropColumn("POS.PERSONS", "IsStudent");
        }
    }
}
