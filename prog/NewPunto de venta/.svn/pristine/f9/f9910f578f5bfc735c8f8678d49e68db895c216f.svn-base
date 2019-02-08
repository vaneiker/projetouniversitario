namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v301 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.BUSINESS_LINE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.ST_GLOBAL_COUNTRYBusinessLine",
                c => new
                    {
                        ST_GLOBAL_COUNTRY_Global_Country_Id = c.Int(nullable: false),
                        BusinessLine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ST_GLOBAL_COUNTRY_Global_Country_Id, t.BusinessLine_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.ST_GLOBAL_COUNTRY_Global_Country_Id, cascadeDelete: true)
                .ForeignKey("POS.BUSINESS_LINE", t => t.BusinessLine_Id, cascadeDelete: true)
                .Index(t => t.ST_GLOBAL_COUNTRY_Global_Country_Id)
                .Index(t => t.BusinessLine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("POS.ST_GLOBAL_COUNTRYBusinessLine", "BusinessLine_Id", "POS.BUSINESS_LINE");
            DropForeignKey("POS.ST_GLOBAL_COUNTRYBusinessLine", "ST_GLOBAL_COUNTRY_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropIndex("POS.ST_GLOBAL_COUNTRYBusinessLine", new[] { "BusinessLine_Id" });
            DropIndex("POS.ST_GLOBAL_COUNTRYBusinessLine", new[] { "ST_GLOBAL_COUNTRY_Global_Country_Id" });
            DropTable("POS.ST_GLOBAL_COUNTRYBusinessLine");
            DropTable("POS.BUSINESS_LINE");
        }
    }
}
