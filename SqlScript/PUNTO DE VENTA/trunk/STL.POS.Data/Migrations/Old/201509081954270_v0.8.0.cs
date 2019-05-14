namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v080 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.QUOTATION", "ApplicantName", c => c.String());
            AddColumn("POS.QUOTATION", "ApplicantId", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "ApplicantContributorId", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "ApplicantContributorName", c => c.String());
            AddColumn("POS.QUOTATION", "PaymentFrequencyId", c => c.Int(nullable: false));
            AddColumn("POS.QUOTATION", "PaymentFrequency", c => c.String());
            AddColumn("POS.QUOTATION", "PaymentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("POS.QUOTATION", "PaymentDate");
            DropColumn("POS.QUOTATION", "PaymentFrequency");
            DropColumn("POS.QUOTATION", "PaymentFrequencyId");
            DropColumn("POS.QUOTATION", "ApplicantContributorName");
            DropColumn("POS.QUOTATION", "ApplicantContributorId");
            DropColumn("POS.QUOTATION", "ApplicantId");
            DropColumn("POS.QUOTATION", "ApplicantName");
        }
    }
}
