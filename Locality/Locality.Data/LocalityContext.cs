﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
