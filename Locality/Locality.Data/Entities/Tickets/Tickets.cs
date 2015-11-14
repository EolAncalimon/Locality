using System;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Users;

namespace Localisty.Data.Entities.Tickets
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual Events Event { get; set; }
        public string Barcode { get; set; }
        public bool Used { get; set; }
    }
}
