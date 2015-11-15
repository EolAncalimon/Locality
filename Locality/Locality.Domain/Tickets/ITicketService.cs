using System.Threading.Tasks;

namespace Locality.Domain.Tickets
{
    public interface ITicketService
    {
        void AddTicket(Localisty.Data.Entities.Tickets.Tickets entity);
    }
}