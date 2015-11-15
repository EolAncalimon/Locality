using Locality.Data.Entities.Events;
using Locality.Data.Entities.Preferences;

namespace Locality.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Locality.Data.LocalityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Locality.Data.LocalityContext context)
        {
            context.Preferences.AddOrUpdate(
                pref => pref.Id,
                new Preferences { Description = "Comedy"},
                new Preferences {Description = "Dance"},
                new Preferences {Description = "Pop"},
                new Preferences {Description = "Rock"});

            context.Events.AddOrUpdate(
                ev => ev.Name,
                new Events
                {
                    Id = Guid.NewGuid(), TicketsRemaining = 50, Name="Fallover Boy", AddressLineOne="The Boderline", City = "London", Postcode = "W1D 4JB",
                    EventImageUrl = "http://cdn.londonandpartners.com/asset/7d1923b0dbeaf5f967802b708e35d1f9.jpg", Price = new decimal(20.00), Start = DateTime.Now.AddHours(12.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 50,
                    Name = "Fallover Boy",
                    AddressLineOne = "The Boderline",
                    City = "London",
                    Postcode = "W1D 4JB",
                    EventImageUrl = "http://cdn.londonandpartners.com/asset/7d1923b0dbeaf5f967802b708e35d1f9.jpg",
                    Price = new decimal(20.00),
                    Start = DateTime.Now.AddHours(12.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 150,
                    Name = "Jazz Tribulation",
                    AddressLineOne = "Ronnie Scott's",
                    City = "London",
                    Postcode = "W1D 4HT",
                    EventImageUrl = "https://media.timeout.com/images/119695/617/463/image.jpg",
                    Price = 25,
                    Start = DateTime.Now.AddHours(2.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 200,
                    Name = "Talented Tortoise",
                    AddressLineOne = "229 The Venue",
                    City = "London",
                    Postcode = " W1W 5PN",
                    EventImageUrl = "http://www.spizzenergi.com/images/Energileeds2013.jpg",
                    Price = new decimal(10.00),
                    Start = DateTime.Now.AddHours(12.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 60,
                    Name = "Unfinished Breast",
                    AddressLineOne = "Electric Ballroom",
                    City = "London",
                    Postcode = "NW1 8QP",
                    EventImageUrl = "http://www.thearcadiaonline.com/wp-content/uploads/2014/03/240373_10150270056480845_25650640844_9308527_3199337_o1.jpg",
                    Price = new decimal(12.50),
                    Start = DateTime.Now.AddHours(15.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 50,
                    Name = "Particular Needle And The Factor",
                    AddressLineOne = "Roundhouse",
                    City = "London",
                    Postcode = "NW1 8EH",
                    EventImageUrl = "http://www.visitbritainblog.com/wp-content/uploads/2011/07/the-roundhouse-london-theatre-600.jpg",
                    Price = new decimal(33.00),
                    Start = DateTime.Now.AddHours(12.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 30,
                    Name = "Barry Graham",
                    AddressLineOne = "7 on Red Comedy Club",
                    City = "London",
                    Postcode = "WC2H 9LA",
                    EventImageUrl = "https://www.clairehaigh.co.uk/images/performance/omid_djaliliHK7B8480_edit.jpg",
                    Price = new decimal(22.50),
                    Start = DateTime.Now.AddHours(10.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 35,
                    Name = "Shelly McGraff",
                    AddressLineOne = "The Boat Show Comedy Club",
                    City = "London",
                    Postcode = "SW1A 2HR",
                    EventImageUrl = "http://cdn.ltstatic.com/2006/October/VR456524_942long.jpg",
                    Price = new decimal(7.50),
                    Start = DateTime.Now.AddHours(8.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 25,
                    Name = "Jam Sessions",
                    AddressLineOne = "The Alley Cat",
                    City = "London",
                    Postcode = "WC2H 8LP",
                    EventImageUrl = "http://hannahrobinsonmusic.co.uk/wp-content/uploads/2013/05/image9.jpg",
                    Price = new decimal(1.50),
                    Start = DateTime.Now.AddHours(12.0),
                    HasTicket = false
                },
                new Events
                {
                    Id = Guid.NewGuid(),
                    TicketsRemaining = 50,
                    Name = "Adopted Posse",
                    AddressLineOne = "Surya Live Music Venue",
                    City = "London",
                    Postcode = "N1 9JL",
                    EventImageUrl = "http://www.clubsurya.co.uk/img/slider/slide7.jpg",
                    Price = new decimal(5.00),
                    Start = DateTime.Now.AddHours(5.0),
                    HasTicket = false
                });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
