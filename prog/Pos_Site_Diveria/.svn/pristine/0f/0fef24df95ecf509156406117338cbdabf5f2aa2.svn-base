namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v081 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "ApplicantIdentification", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "ApplicantContributor", c => c.String(maxLength: 50));
            AlterColumn("POS.QUOTATION", "ApplicantName", c => c.String(maxLength: 50));
            AlterColumn("POS.QUOTATION", "PaymentFrequency", c => c.String(maxLength: 20));
            DropColumn("POS.QUOTATION", "ApplicantContributorId");
            DropColumn("POS.QUOTATION", "ApplicantContributorName");
        }
        
        public override void Down()
        {
            AddColumn("POS.QUOTATION", "ApplicantContributorName", c => c.String());
            AddColumn("POS.QUOTATION", "ApplicantContributorId", c => c.Int(nullable: false));
            AlterColumn("POS.QUOTATION", "PaymentFrequency", c => c.String());
            AlterColumn("POS.QUOTATION", "ApplicantName", c => c.String());
            DropColumn("POS.QUOTATION", "ApplicantContributor");
            DropColumn("POS.QUOTATION", "ApplicantIdentification");
        }
    }
}
