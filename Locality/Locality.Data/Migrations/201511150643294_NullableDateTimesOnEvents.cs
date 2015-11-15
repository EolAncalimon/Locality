namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTimesOnEvents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Start", c => c.DateTime());
            AlterColumn("dbo.Events", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "Start", c => c.DateTime(nullable: false));
        }
    }
}
