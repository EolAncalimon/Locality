namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRestOfTheEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Start = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddressLineOne = c.String(),
                        City = c.String(),
                        Postcode = c.String(),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                        TicketsRemaining = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventPrefences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Events_Id = c.Guid(),
                        Prefences_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Events_Id)
                .ForeignKey("dbo.Preferences", t => t.Prefences_Id)
                .Index(t => t.Events_Id)
                .Index(t => t.Prefences_Id);
            
            CreateTable(
                "dbo.Preferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Barcode = c.String(),
                        Used = c.Boolean(nullable: false),
                        Event_Id = c.Guid(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Prefences_Id = c.Int(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Preferences", t => t.Prefences_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Prefences_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Users", "FacebookToken", c => c.String());
            AddColumn("dbo.Users", "CardToken", c => c.String());
            AddColumn("dbo.Users", "LastFourDigits", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPreferences", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPreferences", "Prefences_Id", "dbo.Preferences");
            DropForeignKey("dbo.Tickets", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventPrefences", "Prefences_Id", "dbo.Preferences");
            DropForeignKey("dbo.EventPrefences", "Events_Id", "dbo.Events");
            DropIndex("dbo.UserPreferences", new[] { "User_Id" });
            DropIndex("dbo.UserPreferences", new[] { "Prefences_Id" });
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropIndex("dbo.Tickets", new[] { "Event_Id" });
            DropIndex("dbo.EventPrefences", new[] { "Prefences_Id" });
            DropIndex("dbo.EventPrefences", new[] { "Events_Id" });
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "LastFourDigits");
            DropColumn("dbo.Users", "CardToken");
            DropColumn("dbo.Users", "FacebookToken");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.Tickets");
            DropTable("dbo.Preferences");
            DropTable("dbo.EventPrefences");
            DropTable("dbo.Events");
        }
    }
}
