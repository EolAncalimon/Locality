namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedPreferences : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventPrefences", newName: "EventPreferences");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EventPreferences", newName: "EventPrefences");
        }
    }
}
