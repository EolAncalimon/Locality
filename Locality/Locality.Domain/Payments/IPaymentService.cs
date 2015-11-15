using System.Threading.Tasks;
using Localisty.Data.Entities.Tickets;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Users;

namespace Locality.Domain.Payments
{
    public interface IPaymentService
    {
        Task<Localisty.Data.Entities.Tickets.Tickets> BuyTicketWithToken(string token, Data.Entities.Events.Events buyEvent, User userBuying);

        Task<Localisty.Data.Entities.Tickets.Tickets> BuyTicketWithCustomer(string custoerId, Data.Entities.Events.Events buyEvent, User userBuying);
    }
}