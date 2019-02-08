namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v086 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "ApplicantIdent", c => c.String(maxLength: 50));
            DropColumn("POS.QUOTATION", "ApplicantId");
            DropColumn("POS.QUOTATION", "ApplicantIdentification");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "ApplicantIdentification", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "ApplicantId", c => c.Int(nullable: false));
            DropColumn("POS.QUOTATION", "ApplicantIdent");
        }
    }
}
