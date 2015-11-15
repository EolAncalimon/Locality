using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Locality.Data.Repositories;

namespace Locality.Domain.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Data.Entities.Tickets.Tickets> _repository;

        public TicketService(IRepository<Data.Entities.Tickets.Tickets> repository)
        {
            _repository = repository;
        }

        public async Task AddTicket(Data.Entities.Tickets.Tickets entity)
        {
           _repository.Add(entity);
            await _repository.SaveChangesAsync();
        }

        public IEnumerable<Data.Entities.Tickets.Tickets> GetTicketsForUser(Guid id)
        {
            return  _repository.List(ticket => ticket.UserId == id);
        }
    }
}