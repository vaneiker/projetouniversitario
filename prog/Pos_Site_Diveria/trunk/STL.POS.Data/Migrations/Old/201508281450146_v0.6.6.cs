namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v066 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" }, "Global.ST_VEHICLE_VERSION");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" });
            AddColumn("POS.VEHICLE_PRODUCT", "Cylinders", c => c.Byte());
            AddColumn("POS.VEHICLE_PRODUCT", "Weight", c => c.Int());
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleModel_Make_Id", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleModel_Model_Id", c => c.Int(nullable: false));
            CreateIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" });
            AddForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" }, "Global.ST_VEHICLE_MODEL", new[] { "Make_Id", "Model_Id" });
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Make_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Model_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Version_Id");
        }
        
        public override void Down()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Version_Id", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Model_Id", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "VehicleVersion_Make_Id", c => c.Int(nullable: false));
            DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" }, "Global.ST_VEHICLE_MODEL");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleModel_Make_Id", "VehicleModel_Model_Id" });
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleModel_Model_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "VehicleModel_Make_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "Weight");
            DropColumn("POS.VEHICLE_PRODUCT", "Cylinders");
            CreateIndex("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" });
            AddForeignKey("POS.VEHICLE_PRODUCT", new[] { "VehicleVersion_Make_Id", "VehicleVersion_Model_Id", "VehicleVersion_Version_Id" }, "Global.ST_VEHICLE_VERSION", new[] { "Make_Id", "Model_Id", "Version_Id" });
        }
    }
}
