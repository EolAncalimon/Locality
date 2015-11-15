namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SortRelationshipsOut : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            RenameColumn(table: "dbo.Tickets", name: "Event_Id", newName: "EventId");
            RenameColumn(table: "dbo.Tickets", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Tickets", "EventId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tickets", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tickets", "UserId");
            CreateIndex("dbo.Tickets", "EventId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            AlterColumn("dbo.Tickets", "UserId", c => c.Guid());
            AlterColumn("dbo.Tickets", "EventId", c => c.Guid());
            RenameColumn(table: "dbo.Tickets", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Tickets", name: "EventId", newName: "Event_Id");
            CreateIndex("dbo.Tickets", "User_Id");
            CreateIndex("dbo.Tickets", "Event_Id");
            AddForeignKey("dbo.Tickets", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Tickets", "Event_Id", "dbo.Events", "Id");
        }
    }
}
