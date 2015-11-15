namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FacebookApiChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventImageUrl", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Events", "EventImageUrl");
        }
    }
}
