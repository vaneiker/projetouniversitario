namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0111 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("POS.PARAMETERS", "Name", name: "ix_parameter_name");
        }
        
        public override void Down()
        {
            DropIndex("POS.PARAMETERS", "ix_parameter_name");
        }
    }
}
