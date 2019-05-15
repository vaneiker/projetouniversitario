namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v220 : DbMigration
    {
        public override void Up()
        {
            DropColumn("POS.QUOTATION", "ApplicantName");
            DropColumn("POS.QUOTATION", "ApplicantIdent");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "ApplicantIdent", c => c.String(maxLength: 50));
            AddColumn("POS.QUOTATION", "ApplicantName", c => c.String(maxLength: 50));
        }
    }
}
