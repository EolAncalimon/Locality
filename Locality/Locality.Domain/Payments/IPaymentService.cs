using System.Threading.Tasks;
using Localisty.Data.Entities.Tickets;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Users;

namespace Locality.Domain.Payments
{
    public interface IPaymentService
    {
        Task<Tickets> BuyTicketWithToken(string token, Events buyEvent, User userBuying);

        Task<Tickets> BuyTicketWithCustomer(string custoerId, Events buyEvent, User userBuying);
    }
}