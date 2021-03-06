﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locality.Data.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FacebookId { get; set; }
        public string FacebookToken { get; set; }
        public string Name { get; set; }
        public string CustomerId { get; set; }
        public int LastFourDigits { get; set; }

        public virtual ICollection<UserPreferences> Preferences { get; set; } 

        public virtual ICollection<Tickets.Tickets> Tickets { get; set; } 

        public DateTime UpdatedAt { get; set; }
    }
}
