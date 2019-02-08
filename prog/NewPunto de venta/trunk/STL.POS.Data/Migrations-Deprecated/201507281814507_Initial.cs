namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Global.ST_VEHICLE_MAKE",
                c => new
                    {
                        Make_Id = c.Int(nullable: false),
                        Make_Desc = c.String(nullable: false, maxLength: 60, unicode: false),
                        Make_Status = c.Boolean(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Make_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_MODEL",
                c => new
                    {
                        Make_Id = c.Int(nullable: false),
                        Model_Id = c.Int(nullable: false),
                        Vehicle_Type_Id = c.Int(nullable: false),
                        Model_Desc = c.String(nullable: false, maxLength: 60, unicode: false),
                        Vehicle_Model_status = c.Boolean(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.Make_Id, t.Model_Id })
                .ForeignKey("Global.ST_VEHICLE_TYPE", t => t.Vehicle_Type_Id)
                .ForeignKey("Global.ST_VEHICLE_MAKE", t => t.Make_Id)
                .Index(t => t.Make_Id)
                .Index(t => t.Vehicle_Type_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_TYPE",
                c => new
                    {
                        Vehicle_Type_Id = c.Int(nullable: false),
                        Vehicle_Type_Desc = c.String(nullable: false, maxLength: 60, unicode: false),
                        Vehicle_Type_Status = c.Boolean(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                        namekey = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Vehicle_Type_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_TYPE_PRODUCT",
                c => new
                    {
                        Corp_Id = c.Int(nullable: false),
                        Region_Id = c.Int(nullable: false),
                        Country_Id = c.Int(nullable: false),
                        Bl_Type_Id = c.Int(nullable: false),
                        Bl_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Vehicle_Type_Id = c.Int(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.Corp_Id, t.Region_Id, t.Country_Id, t.Bl_Type_Id, t.Bl_Id, t.Product_Id, t.Vehicle_Type_Id })
                .ForeignKey("Global.ST_VEHICLE_TYPE", t => t.Vehicle_Type_Id)
                .Index(t => t.Vehicle_Type_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_VERSION",
                c => new
                    {
                        Make_Id = c.Int(nullable: false),
                        Model_Id = c.Int(nullable: false),
                        Version_Id = c.Int(nullable: false),
                        Vehicle_Type_Id = c.Int(nullable: false),
                        Version_Desc = c.String(nullable: false, maxLength: 150, unicode: false),
                        Model_Year = c.Int(),
                        Body_Style = c.String(maxLength: 100, unicode: false),
                        Cylinder = c.Int(nullable: false),
                        Engine_Type = c.String(maxLength: 100, unicode: false),
                        Engine_RPM = c.String(maxLength: 50, unicode: false),
                        Fuel_Int = c.Int(nullable: false),
                        Co2_Emissions = c.String(maxLength: 100, unicode: false),
                        Top_Speed_Kph = c.String(maxLength: 100, unicode: false),
                        Drive_Type = c.String(maxLength: 100, unicode: false),
                        Transmission_Type = c.String(maxLength: 100, unicode: false),
                        Seats = c.Int(nullable: false),
                        Doors = c.String(maxLength: 100, unicode: false),
                        Weight_Kg = c.Int(),
                        Sold_In_USA = c.Boolean(),
                        Load_Capacity_Tons = c.Decimal(precision: 8, scale: 2, storeType: "numeric"),
                        Load_Capacity_Pound = c.Decimal(precision: 8, scale: 2, storeType: "numeric"),
                        HP = c.Int(),
                        LT_CubicCentimeter = c.Decimal(precision: 8, scale: 2, storeType: "numeric"),
                        Version_Status = c.Boolean(nullable: false),
                        Valor_Referencia_Dgii = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => new { t.Make_Id, t.Model_Id, t.Version_Id })
                .ForeignKey("Global.ST_VEHICLE_TYPE", t => t.Vehicle_Type_Id)
                .ForeignKey("Global.ST_VEHICLE_MODEL", t => new { t.Make_Id, t.Model_Id })
                .Index(t => new { t.Make_Id, t.Model_Id })
                .Index(t => t.Vehicle_Type_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_STORED",
                c => new
                    {
                        Stored_Id = c.Int(nullable: false),
                        Stored_Desc = c.String(maxLength: 100, unicode: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Stored_Id);
            
            CreateTable(
                "Global.ST_VEHICLE_USAGE",
                c => new
                    {
                        Usage_Id = c.Int(nullable: false, identity: true),
                        Usage_Desc = c.String(maxLength: 50, unicode: false),
                        Create_Date = c.DateTime(nullable: false),
                        Modi_Date = c.DateTime(),
                        Create_UsrId = c.Int(nullable: false),
                        Modi_UsrId = c.Int(),
                        Hostname = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Usage_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Global.ST_VEHICLE_MODEL", "Make_Id", "Global.ST_VEHICLE_MAKE");
            DropForeignKey("Global.ST_VEHICLE_VERSION", new[] { "Make_Id", "Model_Id" }, "Global.ST_VEHICLE_MODEL");
            DropForeignKey("Global.ST_VEHICLE_VERSION", "Vehicle_Type_Id", "Global.ST_VEHICLE_TYPE");
            DropForeignKey("Global.ST_VEHICLE_TYPE_PRODUCT", "Vehicle_Type_Id", "Global.ST_VEHICLE_TYPE");
            DropForeignKey("Global.ST_VEHICLE_MODEL", "Vehicle_Type_Id", "Global.ST_VEHICLE_TYPE");
            DropIndex("Global.ST_VEHICLE_VERSION", new[] { "Vehicle_Type_Id" });
            DropIndex("Global.ST_VEHICLE_VERSION", new[] { "Make_Id", "Model_Id" });
            DropIndex("Global.ST_VEHICLE_TYPE_PRODUCT", new[] { "Vehicle_Type_Id" });
            DropIndex("Global.ST_VEHICLE_MODEL", new[] { "Vehicle_Type_Id" });
            DropIndex("Global.ST_VEHICLE_MODEL", new[] { "Make_Id" });
            DropTable("Global.ST_VEHICLE_USAGE");
            DropTable("Global.ST_VEHICLE_STORED");
            DropTable("Global.ST_VEHICLE_VERSION");
            DropTable("Global.ST_VEHICLE_TYPE_PRODUCT");
            DropTable("Global.ST_VEHICLE_TYPE");
            DropTable("Global.ST_VEHICLE_MODEL");
            DropTable("Global.ST_VEHICLE_MAKE");
        }
    }
}
