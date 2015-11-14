using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localisty.Data.Entities.Tickets;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Preferences;
using Locality.Data.Entities.Users;

namespace Locality.Data
{
    public class LocalityContext : DbContext
    {
        public LocalityContext() : base("Locality")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Events> Events { get; set; }

        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Preferences> Preferences { get; set; }
    }
}
