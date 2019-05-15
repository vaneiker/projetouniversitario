namespace STL.POS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v251 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "POS.POS_LOG_ENTRY",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        QuotationId = c.Int(nullable: false),
                        CurrentUser = c.String(),
                        Message = c.String(),
                        Priority = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        Severity = c.Int(nullable: false),
                        Title = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        MachineName = c.String(),
                        AppDomainName = c.String(),
                        ProcessId = c.String(),
                        ProcessName = c.String(),
                        ManagedThreadName = c.String(),
                        Win32ThreadId = c.String(),
                        ActivityId = c.Guid(nullable: false),
                        RelatedActivityId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("POS.POS_LOG_ENTRY");
        }
    }
}
