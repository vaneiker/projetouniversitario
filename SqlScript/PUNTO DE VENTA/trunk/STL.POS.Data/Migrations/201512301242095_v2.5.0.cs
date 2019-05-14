namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v250 : DbMigration
    {
        public override void Up()
        {
            DropColumn("POS.QUOTATION", "ApplicantContributor");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "ApplicantContributor", c => c.String(maxLength: 50));
        }
    }
}
