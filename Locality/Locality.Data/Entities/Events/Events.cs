using System;
using System.Collections.Generic;
using Localisty.Data.Entities.Tickets;

namespace Locality.Data.Entities.Events
{
    public class Events
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public decimal Price { get; set; }
        public string AddressLineOne { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int TicketsRemaining { get; set; }

        public string EventImageUrl { get; set; }
        public virtual ICollection<EventPrefences> Prefences { get; set; } 

        public virtual ICollection<Tickets> Tickets { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}