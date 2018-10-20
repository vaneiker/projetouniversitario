using System;
using System.Data.Entity.Migrations;

public partial class v057 : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "POS.COVERAGE_GROUPS_EXTENDED_PROPERTIES",
            c => new
                {
                    GroupId = c.Int(nullable: false, identity: true),
                    CoverageGroupType = c.Int(nullable: false),
                    ST_COVERAGES_GROUP_Corp_Id = c.Int(nullable: false),
                    ST_COVERAGES_GROUP_Group_Id = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.GroupId)
            .ForeignKey("Global.ST_COVERAGES_GROUP", t => new { t.ST_COVERAGES_GROUP_Corp_Id, t.ST_COVERAGES_GROUP_Group_Id }, cascadeDelete: true)
            .Index(t => new { t.ST_COVERAGES_GROUP_Corp_Id, t.ST_COVERAGES_GROUP_Group_Id });
        
    }
    
    public override void Down()
    {
        DropForeignKey("POS.COVERAGE_GROUPS_EXTENDED_PROPERTIES", new[] { "ST_COVERAGES_GROUP_Corp_Id", "ST_COVERAGES_GROUP_Group_Id" }, "Global.ST_COVERAGES_GROUP");
        DropIndex("POS.COVERAGE_GROUPS_EXTENDED_PROPERTIES", new[] { "ST_COVERAGES_GROUP_Corp_Id", "ST_COVERAGES_GROUP_Group_Id" });
        DropTable("POS.COVERAGE_GROUPS_EXTENDED_PROPERTIES");
    }
}
