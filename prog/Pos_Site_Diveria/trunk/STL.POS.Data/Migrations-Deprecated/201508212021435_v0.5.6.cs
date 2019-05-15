using System;
using System.Data.Entity.Migrations;

public partial class v056 : DbMigration
{
    public override void Up()
    {
        AddColumn("POS.TERM_TYPES", "TimeSpanInLetters", c => c.String(maxLength: 50));
    }
    
    public override void Down()
    {
        DropColumn("POS.TERM_TYPES", "TimeSpanInLetters");
    }
}
