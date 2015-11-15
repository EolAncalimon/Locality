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
                ev => ev.Id,
                new Events
                {
                    Id = Guid.NewGuid(), TicketsRemaining = 50, Name="Fallover Boy", AddressLineOne="The Boderline", City = "London", Postcode = "W1D 4JB",
                    EventImageUrl = "http://cdn.londonandpartners.com/asset/7d1923b0dbeaf5f967802b708e35d1f9.jpg", Price = new decimal(20.00), Start = DateTime.Now.AddHours(12.0)
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
