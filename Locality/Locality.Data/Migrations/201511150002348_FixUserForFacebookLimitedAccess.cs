namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserForFacebookLimitedAccess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
    }
}
