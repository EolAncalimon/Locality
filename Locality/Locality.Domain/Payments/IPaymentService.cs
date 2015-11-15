using System.Threading.Tasks;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Users;

namespace Locality.Domain.Payments
{
    public interface IPaymentService
    {
        Task<Data.Entities.Tickets.Tickets> BuyTicketWithToken(string token, Data.Entities.Events.Events buyEvent, User userBuying);

        Task<Data.Entities.Tickets.Tickets> BuyTicketWithCustomer(Data.Entities.Events.Events buyEvent, User userBuying);
    }
}