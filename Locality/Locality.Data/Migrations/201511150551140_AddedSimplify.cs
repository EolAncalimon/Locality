namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSimplify : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CustomerId", c => c.String());
            DropColumn("dbo.Users", "CardToken");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CardToken", c => c.String());
            DropColumn("dbo.Users", "CustomerId");
        }
    }
}
