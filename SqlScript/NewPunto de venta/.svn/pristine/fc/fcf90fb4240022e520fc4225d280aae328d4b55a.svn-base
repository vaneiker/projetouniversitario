namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v306 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropForeignKey("POS.PERSONS", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.PERSONS", "QuotationId", "POS.QUOTATION_SALUD");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS");
            DropIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropIndex("POS.DRIVERS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            DropIndex("POS.PERSONS", new[] { "WorkNationality_Global_Country_Id" });
            DropIndex("POS.PERSONS", new[] { "QuotationId" });
            DropPrimaryKey("POS.DRIVERS");
            DropColumn("POS.DRIVERS", "Id");
            CreateTable(
                "POS.PERSONS_HEALTH",
                c => new
                {
                    Id = c.Int(nullable: false),
                    WorkCity_Country_Id = c.Int(),
                    WorkCity_Domesticreg_Id = c.Int(),
                    WorkCity_State_Prov_Id = c.Int(),
                    WorkCity_City_Id = c.Int(),
                    WorkNationality_Global_Country_Id = c.Int(),
                    QuotationId = c.Int(nullable: false),
                    Relationship = c.String(maxLength: 50),
                    Email2 = c.String(maxLength: 255),
                    Email3 = c.String(maxLength: 255),
                    IsStudent = c.Boolean(),
                    Prime = c.Decimal(storeType: "money"),
                    Income = c.String(maxLength: 50),
                    WorkAddress = c.String(maxLength: 50),
                    PartnerName = c.String(maxLength: 10),
                    IsSmoker = c.Boolean(),
                    IsHighPressure = c.Boolean(),
                    Weight = c.Decimal(precision: 5, scale: 2),
                    Height = c.Decimal(precision: 5, scale: 2),
                    IsExtremeAthlete = c.Boolean(nullable: false),
                    Condition1 = c.String(),
                    Condition1Description = c.String(),
                    Condition2 = c.String(),
                    Condition2Description = c.String(),
                    Condition3 = c.String(),
                    Condition3Description = c.String(),
                    Complication = c.Boolean(nullable: false),
                    Transplant = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PERSONS", t => t.Id)
                .ForeignKey("Global.ST_GLOBAL_CITY", t => new { t.WorkCity_Country_Id, t.WorkCity_Domesticreg_Id, t.WorkCity_State_Prov_Id, t.WorkCity_City_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.WorkNationality_Global_Country_Id)
                .ForeignKey("POS.QUOTATION_SALUD", t => t.QuotationId)
                .Index(t => t.Id)
                .Index(t => new { t.WorkCity_Country_Id, t.WorkCity_Domesticreg_Id, t.WorkCity_State_Prov_Id, t.WorkCity_City_Id })
                .Index(t => t.WorkNationality_Global_Country_Id)
                .Index(t => t.QuotationId);
            
            AddColumn("POS.PERSONS", "Email", c => c.String(maxLength: 255));
            AddColumn("POS.PERSONS", "IdentificationType", c => c.String());
            AddColumn("POS.PERSONS", "IdentificationNumber", c => c.String());
            AddColumn("POS.DRIVERS", "Id", c=> c.Int(nullable:false));
            AddPrimaryKey("POS.DRIVERS", "Id");
            CreateIndex("POS.DRIVERS", "Id");
            AddForeignKey("POS.DRIVERS", "Id", "POS.PERSONS", "Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS", "Id");
            DropColumn("POS.DRIVERS", "FirstName");
            DropColumn("POS.DRIVERS", "Surname");
            DropColumn("POS.DRIVERS", "Email");
            DropColumn("POS.DRIVERS", "PhoneNumber");
            DropColumn("POS.DRIVERS", "DateOfBirth");
            DropColumn("POS.DRIVERS", "IsPrincipal");
            DropColumn("POS.DRIVERS", "Sex");
            DropColumn("POS.DRIVERS", "Address");
            DropColumn("POS.DRIVERS", "Mobile");
            DropColumn("POS.DRIVERS", "WorkPhone");
            DropColumn("POS.DRIVERS", "IdentificationType");
            DropColumn("POS.DRIVERS", "License");
            DropColumn("POS.DRIVERS", "MaritalStatus");
            DropColumn("POS.DRIVERS", "Job");
            DropColumn("POS.DRIVERS", "Company");
            DropColumn("POS.DRIVERS", "YearsInCompany");
            DropColumn("POS.DRIVERS", "City_Country_Id");
            DropColumn("POS.DRIVERS", "City_Domesticreg_Id");
            DropColumn("POS.DRIVERS", "City_State_Prov_Id");
            DropColumn("POS.DRIVERS", "City_City_Id");
            DropColumn("POS.DRIVERS", "Nationality_Global_Country_Id");
            DropColumn("POS.PERSONS", "Relationship");
            DropColumn("POS.PERSONS", "Email1");
            DropColumn("POS.PERSONS", "Email2");
            DropColumn("POS.PERSONS", "Email3");
            DropColumn("POS.PERSONS", "IsStudent");
            DropColumn("POS.PERSONS", "Prime");
            DropColumn("POS.PERSONS", "Income");
            DropColumn("POS.PERSONS", "WorkAddress");
            DropColumn("POS.PERSONS", "PartnerName");
            DropColumn("POS.PERSONS", "IsSmoker");
            DropColumn("POS.PERSONS", "IsHighPressure");
            DropColumn("POS.PERSONS", "Weight");
            DropColumn("POS.PERSONS", "Height");
            DropColumn("POS.PERSONS", "IsExtremeAthlete");
            DropColumn("POS.PERSONS", "Condition1");
            DropColumn("POS.PERSONS", "Condition1Description");
            DropColumn("POS.PERSONS", "Condition2");
            DropColumn("POS.PERSONS", "Condition2Description");
            DropColumn("POS.PERSONS", "Condition3");
            DropColumn("POS.PERSONS", "Condition3Description");
            DropColumn("POS.PERSONS", "Complication");
            DropColumn("POS.PERSONS", "Transplant");
            DropColumn("POS.PERSONS", "WorkCity_Country_Id");
            DropColumn("POS.PERSONS", "WorkCity_Domesticreg_Id");
            DropColumn("POS.PERSONS", "WorkCity_State_Prov_Id");
            DropColumn("POS.PERSONS", "WorkCity_City_Id");
            DropColumn("POS.PERSONS", "WorkNationality_Global_Country_Id");
            DropColumn("POS.PERSONS", "QuotationId");
        }
        
        public override void Down()
        {
            AddColumn("POS.PERSONS", "QuotationId", c => c.Int(nullable: false));
            AddColumn("POS.PERSONS", "WorkNationality_Global_Country_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_City_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_State_Prov_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_Domesticreg_Id", c => c.Int());
            AddColumn("POS.PERSONS", "WorkCity_Country_Id", c => c.Int());
            AddColumn("POS.PERSONS", "Transplant", c => c.Boolean(nullable: false));
            AddColumn("POS.PERSONS", "Complication", c => c.Boolean(nullable: false));
            AddColumn("POS.PERSONS", "Condition3Description", c => c.String());
            AddColumn("POS.PERSONS", "Condition3", c => c.String());
            AddColumn("POS.PERSONS", "Condition2Description", c => c.String());
            AddColumn("POS.PERSONS", "Condition2", c => c.String());
            AddColumn("POS.PERSONS", "Condition1Description", c => c.String());
            AddColumn("POS.PERSONS", "Condition1", c => c.String());
            AddColumn("POS.PERSONS", "IsExtremeAthlete", c => c.Boolean(nullable: false));
            AddColumn("POS.PERSONS", "Height", c => c.Decimal(precision: 5, scale: 2));
            AddColumn("POS.PERSONS", "Weight", c => c.Decimal(precision: 5, scale: 2));
            AddColumn("POS.PERSONS", "IsHighPressure", c => c.Boolean());
            AddColumn("POS.PERSONS", "IsSmoker", c => c.Boolean());
            AddColumn("POS.PERSONS", "PartnerName", c => c.String(maxLength: 10));
            AddColumn("POS.PERSONS", "WorkAddress", c => c.String(maxLength: 50));
            AddColumn("POS.PERSONS", "Income", c => c.String(maxLength: 50));
            AddColumn("POS.PERSONS", "Prime", c => c.Decimal(storeType: "money"));
            AddColumn("POS.PERSONS", "IsStudent", c => c.Boolean());
            AddColumn("POS.PERSONS", "Email3", c => c.String(maxLength: 255));
            AddColumn("POS.PERSONS", "Email2", c => c.String(maxLength: 255));
            AddColumn("POS.PERSONS", "Email1", c => c.String(maxLength: 255));
            AddColumn("POS.PERSONS", "Relationship", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Nationality_Global_Country_Id", c => c.Int());
            AddColumn("POS.DRIVERS", "City_City_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_State_Prov_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_Domesticreg_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "City_Country_Id", c => c.Int(nullable: false));
            AddColumn("POS.DRIVERS", "YearsInCompany", c => c.Int());
            AddColumn("POS.DRIVERS", "Company", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Job", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "MaritalStatus", c => c.String(maxLength: 10));
            AddColumn("POS.DRIVERS", "License", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "IdentificationType", c => c.String(maxLength: 20));
            AddColumn("POS.DRIVERS", "WorkPhone", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Mobile", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Address", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Sex", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "IsPrincipal", c => c.Boolean(nullable: false));
            AddColumn("POS.DRIVERS", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("POS.DRIVERS", "PhoneNumber", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "Email", c => c.String(maxLength: 255));
            AddColumn("POS.DRIVERS", "Surname", c => c.String(maxLength: 50));
            AddColumn("POS.DRIVERS", "FirstName", c => c.String(maxLength: 50));
            DropForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS");
            DropForeignKey("POS.PERSONS_HEALTH", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.PERSONS_HEALTH", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropForeignKey("POS.PERSONS_HEALTH", "Id", "POS.PERSONS");
            DropForeignKey("POS.DRIVERS", "Id", "POS.PERSONS");
            DropIndex("POS.PERSONS_HEALTH", new[] { "QuotationId" });
            DropIndex("POS.PERSONS_HEALTH", new[] { "WorkNationality_Global_Country_Id" });
            DropIndex("POS.PERSONS_HEALTH", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            DropIndex("POS.PERSONS_HEALTH", new[] { "Id" });
            DropIndex("POS.DRIVERS", new[] { "Id" });
            DropPrimaryKey("POS.DRIVERS");
            AlterColumn("POS.DRIVERS", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("POS.PERSONS", "IdentificationNumber");
            DropColumn("POS.PERSONS", "IdentificationType");
            DropColumn("POS.PERSONS", "Email");
            DropTable("POS.PERSONS_HEALTH");
            AddPrimaryKey("POS.DRIVERS", "Id");
            CreateIndex("POS.PERSONS", "QuotationId");
            CreateIndex("POS.PERSONS", "WorkNationality_Global_Country_Id");
            CreateIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            CreateIndex("POS.DRIVERS", "Nationality_Global_Country_Id");
            CreateIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            AddForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS", "Id");
            AddForeignKey("POS.PERSONS", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY", "Global_Country_Id");
            AddForeignKey("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY", new[] { "Country_Id", "Domesticreg_Id", "State_Prov_Id", "City_Id" });
        }
    }
}
