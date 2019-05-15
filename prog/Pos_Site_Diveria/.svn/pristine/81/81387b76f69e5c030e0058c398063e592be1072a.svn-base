namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v067 : DbMigration
    {
        public override void Up()
        {
            AddColumn("POS.VEHICLE_PRODUCT", "Passengers", c => c.Short());
        }
        
        public override void Down()
        {
            DropColumn("POS.VEHICLE_PRODUCT", "Passengers");
        }
    }
}
