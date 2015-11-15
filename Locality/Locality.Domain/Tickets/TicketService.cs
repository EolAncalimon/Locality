using System.Threading.Tasks;
using Locality.Data.Repositories;

namespace Locality.Domain.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Localisty.Data.Entities.Tickets.Tickets> _repository;

        public TicketService(IRepository<Localisty.Data.Entities.Tickets.Tickets> repository)
        {
            _repository = repository;
        }

        public  void AddTicket(Localisty.Data.Entities.Tickets.Tickets entity)
        {
           _repository.Add(entity);
        }
    }
}