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
