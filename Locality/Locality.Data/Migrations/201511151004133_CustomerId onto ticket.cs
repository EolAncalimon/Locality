namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerIdontoticket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "CustomerId");
        }
    }
}
