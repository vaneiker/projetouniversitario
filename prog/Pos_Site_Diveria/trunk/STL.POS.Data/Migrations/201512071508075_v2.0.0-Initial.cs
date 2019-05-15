namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v200Initial : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "POS.COVERAGE_DETAILS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSelected = c.Boolean(nullable: false),
                        CoverageDetailCoreId = c.Int(nullable: false),
                        Name = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinDeductible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SelfDamagesToProductLimits = c.Int(),
                        ServicesToProductLimits = c.Int(),
                        ThirdPartyToProductLimits = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.SelfDamagesToProductLimits)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.ServicesToProductLimits)
                .ForeignKey("POS.PRODUCT_LIMITS", t => t.ThirdPartyToProductLimits)
                .Index(t => t.SelfDamagesToProductLimits)
                .Index(t => t.ServicesToProductLimits)
                .Index(t => t.ThirdPartyToProductLimits);
            
            CreateTable(
                "POS.DRIVERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 255),
                        PhoneNumber = c.String(maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsPrincipal = c.Boolean(nullable: false),
                        Sex = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        WorkPhone = c.String(maxLength: 50),
                        License = c.String(maxLength: 50),
                        YearsDriving = c.Int(),
                        AccidentsLast3Years = c.String(maxLength: 5),
                        MaritalStatus = c.String(maxLength: 10),
                        Job = c.String(maxLength: 50),
                        Company = c.String(maxLength: 50),
                        YearsInCompany = c.Int(),
                        City_Country_Id = c.Int(nullable: false),
                        City_Domesticreg_Id = c.Int(nullable: false),
                        City_State_Prov_Id = c.Int(nullable: false),
                        City_City_Id = c.Int(nullable: false),
                        Nationality_Global_Country_Id = c.Int(),
                        QuotationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Global.ST_GLOBAL_CITY", t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.Nationality_Global_Country_Id)
                .ForeignKey("POS.QUOTATION_AUTO", t => t.QuotationId)
                .Index(t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .Index(t => t.Nationality_Global_Country_Id)
                .Index(t => t.QuotationId);
            
            CreateTable(
                "POS.PARAMETERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        FriendlyName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 4000),
                        Value = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, name: "ix_parameter_name");
            
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
                        IsStudent = c.Boolean(),
                        IsPrincipal = c.Boolean(nullable: false),
                        Income = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        WorkAddress = c.String(maxLength: 50),
                        PhoneNumber = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 50),
                        WorkPhone = c.String(maxLength: 50),
                        MaritalStatus = c.String(maxLength: 10),
                        PartnerName = c.String(maxLength: 10),
                        Job = c.String(maxLength: 50),
                        Company = c.String(maxLength: 50),
                        YearsInCompany = c.Int(),
                        IsSmoker = c.Boolean(),
                        IsHighPressure = c.Boolean(),
                        Weight = c.Decimal(precision: 5, scale: 2),
                        Height = c.Decimal(precision: 5, scale: 2),
                        Sex = c.String(maxLength: 50),
                        IsExtremeAthlete = c.Boolean(nullable: false),
                        Condition1 = c.String(),
                        Condition1Description = c.String(),
                        Condition2 = c.String(),
                        Condition2Description = c.String(),
                        Condition3 = c.String(),
                        Condition3Description = c.String(),
                        Complication = c.Boolean(nullable: false),
                        Transplant = c.Boolean(nullable: false),
                        City_Country_Id = c.Int(nullable: false),
                        City_Domesticreg_Id = c.Int(nullable: false),
                        City_State_Prov_Id = c.Int(nullable: false),
                        City_City_Id = c.Int(nullable: false),
                        Nationality_Global_Country_Id = c.Int(),
                        WorkCity_Country_Id = c.Int(),
                        WorkCity_Domesticreg_Id = c.Int(),
                        WorkCity_State_Prov_Id = c.Int(),
                        WorkCity_City_Id = c.Int(),
                        WorkNationality_Global_Country_Id = c.Int(),
                        QuotationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Global.ST_GLOBAL_CITY", t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.Nationality_Global_Country_Id)
                .ForeignKey("Global.ST_GLOBAL_CITY", t => new { t.WorkCity_Country_Id, t.WorkCity_Domesticreg_Id, t.WorkCity_State_Prov_Id, t.WorkCity_City_Id })
                .ForeignKey("Global.ST_GLOBAL_COUNTRY", t => t.WorkNationality_Global_Country_Id)
                .ForeignKey("POS.QUOTATION_SALUD", t => t.QuotationId)
                .Index(t => new { t.City_Country_Id, t.City_Domesticreg_Id, t.City_State_Prov_Id, t.City_City_Id })
                .Index(t => t.Nationality_Global_Country_Id)
                .Index(t => new { t.WorkCity_Country_Id, t.WorkCity_Domesticreg_Id, t.WorkCity_State_Prov_Id, t.WorkCity_City_Id })
                .Index(t => t.WorkNationality_Global_Country_Id)
                .Index(t => t.QuotationId);
            
            CreateTable(
                "POS.PRODUCT_LIMITS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsSelected = c.Boolean(nullable: false),
                        SdPrime = c.Decimal(storeType: "money"),
                        TpPrime = c.Decimal(storeType: "money"),
                        ServicesPrime = c.Decimal(storeType: "money"),
                        ISC = c.Decimal(precision: 18, scale: 2),
                        ISCPercentage = c.Decimal(precision: 18, scale: 2),
                        TotalPrime = c.Decimal(storeType: "money"),
                        TotalIsc = c.Decimal(storeType: "money"),
                        TotalDiscount = c.Decimal(storeType: "money"),
                        SelectedDeductibleCoreId = c.Int(),
                        SelectedDeductibleName = c.String(),
                        VehicleProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.VEHICLE_PRODUCT", t => t.VehicleProduct_Id, cascadeDelete: true)
                .Index(t => t.VehicleProduct_Id);
            
            CreateTable(
                "POS.QUOTATION",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductNumber = c.String(maxLength: 2),
                        QuotationDailyNumber = c.Int(nullable: false),
                        QuotationNumber = c.String(maxLength: 20),
                        PolicyNumber = c.String(maxLength: 20),
                        Created = c.DateTime(nullable: false),
                        LastModified = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ApplicantName = c.String(maxLength: 50),
                        ApplicantIdent = c.String(maxLength: 50),
                        ApplicantContributor = c.String(maxLength: 50),
                        PaymentFrequencyId = c.Int(),
                        PaymentFrequency = c.String(maxLength: 20),
                        PaymentWay = c.Int(),
                        AmountToPayEnteredByUser = c.Decimal(precision: 18, scale: 2),
                        CardnetLastResponseCode = c.String(maxLength: 10),
                        CardnetLastResponseMessage = c.String(maxLength: 100),
                        CardnetAuthorizationCode = c.String(maxLength: 10),
                        CardnetPaymentStatus = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        TotalPrime = c.Decimal(storeType: "money"),
                        TotalISC = c.Decimal(storeType: "money"),
                        ISCPercentage = c.Decimal(precision: 18, scale: 2),
                        TotalDiscount = c.Decimal(storeType: "money"),
                        DiscountPercentage = c.Decimal(precision: 18, scale: 2),
                        QuotationCoreIdNumber = c.Decimal(precision: 18, scale: 2),
                        ClientCoreIdNumber = c.Decimal(precision: 18, scale: 2),
                        SendInspectionOnly = c.Boolean(nullable: false),
                        Status = c.Byte(nullable: false),
                        TermType_Id = c.Int(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.TERM_TYPES", t => t.TermType_Id)
                .ForeignKey("POS.USERS", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.TermType_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "POS.TERM_TYPES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        TimeSpanInMonths = c.Int(),
                        TimeSpanInLetters = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.USERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 255),
                        Salt = c.String(maxLength: 500),
                        PasswordEncoded = c.String(maxLength: 500),
                        ChangePasswordToken = c.String(maxLength: 100),
                        UserOrigin = c.Int(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        LastDateModified = c.DateTime(),
                        LastLogin = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "POS.VEHICLE_PRODUCT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleDescription = c.String(maxLength: 500),
                        Year = c.Int(),
                        Cylinders = c.Byte(),
                        Passengers = c.String(),
                        Weight = c.Int(),
                        Chassis = c.String(maxLength: 50),
                        Plate = c.String(maxLength: 50),
                        Color = c.String(maxLength: 50),
                        VehiclePrice = c.Decimal(nullable: false, storeType: "money"),
                        InsuredAmount = c.Decimal(storeType: "money"),
                        PercentageToInsure = c.Decimal(precision: 5, scale: 2),
                        TotalPrime = c.Decimal(storeType: "money"),
                        TotalIsc = c.Decimal(storeType: "money"),
                        TotalDiscount = c.Decimal(storeType: "money"),
                        SelectedProductTypeId = c.Int(),
                        SelectedProductTypeName = c.String(maxLength: 50),
                        SelectedProductCoreId = c.Int(),
                        SelectedProductUsageCoreId = c.Int(),
                        SelectedProductUsageName = c.String(maxLength: 100),
                        VehicleTypeCoreId = c.Int(),
                        SelectedProductName = c.String(maxLength: 100),
                        VehicleTypeName = c.String(maxLength: 60),
                        VehicleMakeName = c.String(maxLength: 60),
                        UsageId = c.Int(nullable: false),
                        UsageName = c.String(maxLength: 50),
                        StoreId = c.Int(nullable: false),
                        StoreName = c.String(maxLength: 50),
                        Driver_Id = c.Int(nullable: false),
                        VehicleModel_Make_Id = c.Int(nullable: false),
                        VehicleModel_Model_Id = c.Int(nullable: false),
                        Quotation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.DRIVERS", t => t.Driver_Id)
                .ForeignKey("Global.ST_VEHICLE_MODEL", t => new { t.VehicleModel_Make_Id, t.VehicleModel_Model_Id })
                .ForeignKey("POS.QUOTATION_AUTO", t => t.Quotation_Id)
                .Index(t => t.Driver_Id)
                .Index(t => new { t.VehicleModel_Make_Id, t.VehicleModel_Model_Id })
                .Index(t => t.Quotation_Id);
            
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
                        PlanType = c.String(maxLength: 50),
                        Plan = c.String(maxLength: 50),
                        Deductible = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("POS.QUOTATION", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("POS.QUOTATION_SALUD", "Id", "POS.QUOTATION");
            DropForeignKey("POS.QUOTATION_AUTO", "Id", "POS.QUOTATION");
            DropForeignKey("POS.PERSONS", "QuotationId", "POS.QUOTATION_SALUD");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Quotation_Id", "POS.QUOTATION_AUTO");
            DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" }, "Global.ST_VEHICLE_MODEL");
            DropForeignKey("POS.PRODUCT_LIMITS", "VehicleProduct_Id", "POS.VEHICLE_PRODUCT");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Driver_Id", "POS.DRIVERS");
            DropForeignKey("POS.DRIVERS", "QuotationId", "POS.QUOTATION_AUTO");
            DropForeignKey("POS.QUOTATION", "User_Id", "POS.USERS");
            DropForeignKey("POS.QUOTATION", "TermType_Id", "POS.TERM_TYPES");
            DropForeignKey("POS.COVERAGE_DETAILS", "ThirdPartyToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.COVERAGE_DETAILS", "ServicesToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.COVERAGE_DETAILS", "SelfDamagesToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.PERSONS", "WorkNationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropForeignKey("POS.PERSONS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropForeignKey("POS.DRIVERS", "Nationality_Global_Country_Id", "Global.ST_GLOBAL_COUNTRY");
            DropForeignKey("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" }, "Global.ST_GLOBAL_CITY");
            DropIndex("POS.QUOTATION_SALUD", new[] { "Id" });
            DropIndex("POS.QUOTATION_AUTO", new[] { "Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Quotation_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Driver_Id" });
            DropIndex("POS.QUOTATION", new[] { "User_Id" });
            DropIndex("POS.QUOTATION", new[] { "TermType_Id" });
            DropIndex("POS.PRODUCT_LIMITS", new[] { "VehicleProduct_Id" });
            DropIndex("POS.PERSONS", new[] { "QuotationId" });
            DropIndex("POS.PERSONS", new[] { "WorkNationality_Global_Country_Id" });
            DropIndex("POS.PERSONS", new[] { "WorkCity_Country_Id", "WorkCity_Domesticreg_Id", "WorkCity_State_Prov_Id", "WorkCity_City_Id" });
            DropIndex("POS.PERSONS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.PERSONS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropIndex("POS.PARAMETERS", "ix_parameter_name");
            DropIndex("POS.DRIVERS", new[] { "QuotationId" });
            DropIndex("POS.DRIVERS", new[] { "Nationality_Global_Country_Id" });
            DropIndex("POS.DRIVERS", new[] { "City_Country_Id", "City_Domesticreg_Id", "City_State_Prov_Id", "City_City_Id" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ThirdPartyToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServicesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "SelfDamagesToProductLimits" });
            DropTable("POS.QUOTATION_SALUD");
            DropTable("POS.QUOTATION_AUTO");
            DropTable("POS.VEHICLE_PRODUCT");
            DropTable("POS.USERS");
            DropTable("POS.TERM_TYPES");
            DropTable("POS.QUOTATION");
            DropTable("POS.PRODUCT_LIMITS");
            DropTable("POS.PERSONS");
            DropTable("POS.PARAMETERS");
            DropTable("POS.DRIVERS");
            DropTable("POS.COVERAGE_DETAILS");
        }
    }
}
