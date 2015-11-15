namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHasticketToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "HasTicket", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "HasTicket");
        }
    }
}
