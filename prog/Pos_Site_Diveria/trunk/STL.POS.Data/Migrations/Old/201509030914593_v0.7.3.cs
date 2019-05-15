namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v073 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("POS.VEHICLE_PRODUCT", "Stored_Stored_Id", "Global.ST_VEHICLE_STORED");
            DropForeignKey("POS.VEHICLE_PRODUCT", "Usage_Usage_Id", "Global.ST_VEHICLE_USAGE");
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Stored_Stored_Id" });
            DropIndex("POS.VEHICLE_PRODUCT", new[] { "Usage_Usage_Id" });
            AddColumn("POS.VEHICLE_PRODUCT", "UsageId", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "StoreId", c => c.Int(nullable: false));
            DropColumn("POS.VEHICLE_PRODUCT", "Stored_Stored_Id");
            DropColumn("POS.VEHICLE_PRODUCT", "Usage_Usage_Id");
        }
        
        public override void Down()
        {
           
            AddColumn("POS.VEHICLE_PRODUCT", "Usage_Usage_Id", c => c.Int(nullable: false));
            AddColumn("POS.VEHICLE_PRODUCT", "Stored_Stored_Id", c => c.Int(nullable: false));
            DropColumn("POS.VEHICLE_PRODUCT", "StoreId");
            DropColumn("POS.VEHICLE_PRODUCT", "UsageId");
            CreateIndex("POS.VEHICLE_PRODUCT", "Usage_Usage_Id");
            CreateIndex("POS.VEHICLE_PRODUCT", "Stored_Stored_Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Usage_Usage_Id", "Global.ST_VEHICLE_USAGE", "Usage_Id");
            AddForeignKey("POS.VEHICLE_PRODUCT", "Stored_Stored_Id", "Global.ST_VEHICLE_STORED", "Stored_Id");
        }
    }
}
