using System;
using System.Data.Entity.Migrations;

public partial class v053 : DbMigration
{
    public override void Up()
    {
        DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" }, "Integration.VW_ST_COVERAGES_GROUP");
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" });
        CreateIndex("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id" });
        AddForeignKey("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id" }, "Global.ST_COVERAGES_GROUP", new[] { "Corp_Id", "Group_Id" });
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Group_Desc");
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Group_Status");
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Create_Date");
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Create_UsrId");
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_hostname");
        DropColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Core_Group_Id");
    }
    
    public override void Down()
    {
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Core_Group_Id", c => c.Int());
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_hostname", c => c.String(maxLength: 100, unicode: false));
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Create_UsrId", c => c.Int());
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Create_Date", c => c.DateTime());
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Group_Status", c => c.Boolean());
        AddColumn("POS.VEHICLE_PRODUCT", "SelectedProduct_Group_Desc", c => c.String(maxLength: 200, unicode: false));
        DropForeignKey("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id" }, "Global.ST_COVERAGES_GROUP");
        DropIndex("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id" });
        CreateIndex("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" });
        AddForeignKey("POS.VEHICLE_PRODUCT", new[] { "SelectedProduct_Corp_Id", "SelectedProduct_Group_Id", "SelectedProduct_Group_Desc", "SelectedProduct_Group_Status", "SelectedProduct_Create_Date", "SelectedProduct_Create_UsrId", "SelectedProduct_hostname", "SelectedProduct_Core_Group_Id" }, "Integration.VW_ST_COVERAGES_GROUP", new[] { "Corp_Id", "Group_Id", "Group_Desc", "Group_Status", "Create_Date", "Create_UsrId", "hostname", "Core_Group_Id" });
    }
}
