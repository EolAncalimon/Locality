using System;

namespace Locality.Data.Entities.Events
{
    public class EventPrefences
    {
        public Guid Id { get; set; }
        public virtual Events Events { get; set; }
        public virtual Preferences.Preferences Prefences { get; set; } 
    }
}