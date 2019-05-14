using System;
using System.Data.Entity.Migrations;

public partial class v054 : DbMigration
{
    public override void Up()
    {
        AlterColumn("POS.DRIVERS", "AccidentsLast3Years", c => c.String(maxLength: 5));
    }
    
    public override void Down()
    {
        AlterColumn("POS.DRIVERS", "AccidentsLast3Years", c => c.Int());
    }
}
