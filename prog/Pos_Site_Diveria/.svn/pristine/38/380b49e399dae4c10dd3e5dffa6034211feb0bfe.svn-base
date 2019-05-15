namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v307 : DbMigration
    {
        public override void Up()
        {
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServicesToProductLimits" });
            DropForeignKey("POS.COVERAGE_DETAILS", "ServicesToProductLimits", "POS.PRODUCT_LIMITS");
            CreateTable(
                "POS.SERVICES_TYPES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        ServicesTypesToProductLimits = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ServicesTypesToProductLimits);
            AddForeignKey("POS.SERVICES_TYPES", "ServicesTypesToProductLimits", "POS.PRODUCT_LIMITS");
            AddColumn("POS.COVERAGE_DETAILS", "ServiceType_Id", c => c.Int(nullable: false));
            CreateIndex("POS.COVERAGE_DETAILS", "ServiceType_Id");
            AddForeignKey("POS.COVERAGE_DETAILS", "ServiceType_Id", "POS.SERVICES_TYPES", "Id", cascadeDelete: true);
            DropColumn("POS.COVERAGE_DETAILS", "ServicesToProductLimits");
        }
        
        public override void Down()
        {
            AddColumn("POS.COVERAGE_DETAILS", "ServicesToProductLimits", c => c.Int());
            DropForeignKey("POS.SERVICES_TYPES", "ServicesTypesToProductLimits", "POS.PRODUCT_LIMITS");
            AddForeignKey("POS.COVERAGE_DETAILS", "ServicesToProductLimits", "POS.PRODUCT_LIMITS");
            DropForeignKey("POS.COVERAGE_DETAILS", "ServiceType_Id", "POS.SERVICES_TYPES");
            DropIndex("POS.SERVICES_TYPES", new[] { "ServicesTypesToProductLimits" });
            DropIndex("POS.COVERAGE_DETAILS", new[] { "ServiceType_Id" });
            DropColumn("POS.COVERAGE_DETAILS", "ServiceType_Id");
            DropTable("POS.SERVICES_TYPES");
            CreateIndex("POS.COVERAGE_DETAILS", "ServicesToProductLimits");
        }
    }
}
