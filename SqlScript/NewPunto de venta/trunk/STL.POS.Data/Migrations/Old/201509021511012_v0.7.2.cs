namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v072 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "Passengers", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("POS.VEHICLE_PRODUCT", "Passengers", c => c.Short());
        }
    }
}
