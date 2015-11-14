using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localisty.Data.Entities.Tickets;

namespace Locality.Data.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FacebookId { get; set; }
        public string FacebookToken { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string CardToken { get; set; }
        public int LastFourDigits { get; set; }

        public virtual ICollection<UserPreferences> Preferences { get; set; } 

        public virtual ICollection<Tickets> Tickets { get; set; } 

        public DateTime UpdatedAt { get; set; }
    }
}
