namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v043 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.VEHICLE_PRODUCT", "TermTypeId", "POS.TERM_TYPES");
            DropForeignKey("POS.VEHICLE_PRODUCT", "FK_POS.VEHICLE_COVERAGE_POS.TERM_TYPES_TermTypeId");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "TermTypeId" });
            AddColumn("POS.QUOTATION", "StartDate", c => c.DateTime());
            AddColumn("POS.QUOTATION", "EndDate", c => c.DateTime());
            AddColumn("POS.QUOTATION", "TermType_Id", c => c.Int());
            CreateIndex("POS.QUOTATION", "TermType_Id");
            AddForeignKey("POS.QUOTATION", "TermType_Id", "POS.TERM_TYPES", "Id");
            DropColumn("POS.VEHICLE_PRODUCT", "TermTypeId");
            DropColumn("POS.VEHICLE_PRODUCT", "StartDate");
            DropColumn("POS.VEHICLE_PRODUCT", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "EndDate", c => c.DateTime());
            AddColumn("POS.VEHICLE_PRODUCT", "StartDate", c => c.DateTime());
            AddColumn("POS.VEHICLE_PRODUCT", "TermTypeId", c => c.Int());
            DropForeignKey("POS.QUOTATION", "TermType_Id", "POS.TERM_TYPES");
            DropIndex("POS.QUOTATION", new[] { "TermType_Id" });
            DropColumn("POS.QUOTATION", "TermType_Id");
            DropColumn("POS.QUOTATION", "EndDate");
            DropColumn("POS.QUOTATION", "StartDate");
            CreateIndex("POS.VEHICLE_PRODUCT", "TermTypeId");
            AddForeignKey("POS.VEHICLE_PRODUCT", "TermTypeId", "POS.TERM_TYPES", "Id");
        }
    }
}
