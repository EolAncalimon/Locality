using System;
using Locality.Data.Entities.Users;

namespace Locality.Data.Entities.Tickets
{
    public class Tickets
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string CustomerId { get; set; }
        public virtual User User { get; set; }
        public Guid EventId { get; set; }
        public virtual Events.Events Event { get; set; }
        public string Barcode { get; set; }
        public bool Used { get; set; }
    }
}
