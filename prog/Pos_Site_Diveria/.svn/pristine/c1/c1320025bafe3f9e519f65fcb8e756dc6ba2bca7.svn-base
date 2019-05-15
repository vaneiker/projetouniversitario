namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v096 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION");
            CreateTable(
                "POS.QUOTATION_AUTO",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.QUOTATION", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "POS.QUOTATION_SALUD",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.QUOTATION", t => t.Id)
                .Index(t => t.Id);
            
            AddForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION_AUTO", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION_AUTO", "Id");

            CreateTable(
               "POS.PERSONS",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   FirstName = c.String(maxLength: 50),
                   SecondName = c.String(maxLength: 50),
                   FirstSurname = c.String(maxLength: 50),
                   SecondSurname = c.String(maxLength: 50),
                   Relationship = c.String(maxLength: 50),
                   DateOfBirth = c.DateTime(nullable: false),
                   Email1 = c.String(maxLength: 255),
                   Email2 = c.String(maxLength: 255),
                   Email3 = c.String(maxLength: 255),
                   IsPrincipal = c.Boolean(nullable: false),
                   Income = c.String(maxLength: 50),
                   Address = c.String(maxLength: 50),
                   WorkAddress = c.String(maxLength: 50),
                   PhoneNumber = c.String(maxLength: 50),
                   Mobile = c.String(maxLength: 50),
                   WorkPhone = c.String(maxLength: 50),
                   MaritalStatus = c.String(maxLength: 50),
                   Job = c.String(maxLength: 50),
                   Company = c.String(maxLength: 50),
                   YearsInCompany = c.Int(nullable: true),
                   IsSmoker = c.Boolean(nullable: true),
                   Sex = c.String(maxLength: 50),
                   IsExtremeAthlete = c.Boolean(nullable: true),
                   Condition1 = c.String(maxLength: 50),
                   Condition1Description = c.String(maxLength: 50),
                   Condition2 = c.String(maxLength: 50),
                   Condition2Description = c.String(maxLength: 50),
                   Condition3 = c.String(maxLength: 50),
                   Condition3Description = c.String(maxLength: 50),
                   Height = c.Decimal(precision: 18, scale: 2),
                   Weight = c.Decimal(precision: 18, scale: 2),
                   QuotationId = c.Int(nullable: false),
                   Nationality_Global_Country_Id = c.Int(),
               })
               .PrimaryKey(t => t.Id)
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.Nationality_Global_Country_Id)
                .ForeignKey("POS.QUOTATION", t => t.QuotationId, cascadeDelete: true)
                .Index(t => t.QuotationId)
                .Index(t => t.Nationality_Global_Country_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("POS.QUOTATION_SALUD", "Id", "POS.QUOTATION");
            DropForeignKey("POS.QUOTATION_AUTO", "Id", "POS.QUOTATION");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION_AUTO");
            DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION_AUTO");
            DropIndex("POS.QUOTATION_SALUD", new[] { "Id" });
            DropIndex("POS.QUOTATION_AUTO", new[] { "Id" });
            DropIndex("POS.PERSONS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.PERSONS", new[] { "QuotationId" });
            DropTable("POS.QUOTATION_SALUD");
            DropTable("POS.QUOTATION_AUTO");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION", "Id", cascadeDelete: true);
            AddForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION", "Id", cascadeDelete: true);
        }
    }
}
