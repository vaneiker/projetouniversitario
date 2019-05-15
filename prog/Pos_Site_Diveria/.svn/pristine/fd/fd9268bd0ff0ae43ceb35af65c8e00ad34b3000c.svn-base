namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v038 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("POS.DRIVERS", "YearsDriving", c => c.Int());
            AlterColumn("POS.DRIVERS", "AccidentsLast3Years", c => c.Int());
            AlterColumn("POS.DRIVERS", "YearsInCompany", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("POS.DRIVERS", "YearsInCompany", c => c.Int(nullable: false));
            AlterColumn("POS.DRIVERS", "AccidentsLast3Years", c => c.Int(nullable: false));
            AlterColumn("POS.DRIVERS", "YearsDriving", c => c.Int(nullable: false));
        }
    }
}
