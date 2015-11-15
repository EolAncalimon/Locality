using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locality.Domain.Tickets
{
    public interface ITicketService
    {
        Task AddTicket(Data.Entities.Tickets.Tickets entity);

        IEnumerable<Data.Entities.Tickets.Tickets> GetTicketsForUser(Guid id);
    }
}