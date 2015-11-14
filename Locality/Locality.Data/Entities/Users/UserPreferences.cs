using System;

namespace Locality.Data.Entities.Users
{
    public class UserPreferences
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; } 
        public virtual Preferences.Preferences Prefences { get; set; }
    }
}