using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localisty.Data.Entities.Tickets;
using Locality.Data.Entities.Events;
using Locality.Data.Entities.Users;
using SimplifyCommerce.Payments;

namespace Locality.Domain.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<Tickets> BuyTicketWithToken(string token, Events buyEvent, User userBuying)
        {
            PaymentsApi.PublicApiKey = "sbpb_MzlkM2M1MjItZDkwZi00NTY5LWI1YzAtOGFiM2Y5YWJlMzQx";
            PaymentsApi.PrivateApiKey = Environment.GetEnvironmentVariable("SimplifyPrivate");

            var api = new PaymentsApi();

            var payment = new Payment
            {
                Amount = (long) buyEvent.Price,
                Currency = "GBP",
                Description = $"Ticket for {buyEvent.Name}",
                Token = new CardToken(token).Id
            };

            var customer = new Customer
            {
                Token = token,
                Name = userBuying.Name,
                Reference = "Locality Customer"
            };

            try
            {
                payment = (Payment) api.Create(payment);
                customer = (Customer) api.Create(customer);

                if (payment.Authorization.Id != null)
                {
                    userBuying.CustomerId = customer.Id;
                    return Task.FromResult(new Tickets
                    {
                        Barcode = payment.Reference,
                        Event = buyEvent,
                        User = userBuying,
                        Used = false
                    });
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        public Task<Tickets> BuyTicketWithCustomer(string customerId, Events buyEvent, User userBuying)
        {
            PaymentsApi.PublicApiKey = "sbpb_MzlkM2M1MjItZDkwZi00NTY5LWI1YzAtOGFiM2Y5YWJlMzQx";
            PaymentsApi.PrivateApiKey = Environment.GetEnvironmentVariable("SimplifyPrivate");

            var api = new PaymentsApi();

            try
            {
                var customer = (Customer) api.Find(typeof (Customer), customerId);

                if (customer == null)
                {
                    return null;
                }
                var payment = new Payment
                {
                    Amount = (long)buyEvent.Price,
                    Currency = "GBP",
                    Description = $"Ticket for {buyEvent.Name}",
                    Token = new CardToken(customer.Token).Id
                };

                payment = (Payment)api.Create(payment);

                if (payment.Authorization.Id != null)
                {
                    return Task.FromResult(new Tickets
                    {
                        Barcode = payment.Reference,
                        Event = buyEvent,
                        User = userBuying,
                        Used = false
                    });
                }

                return null;

            }
            catch
            {
                return null;
            }
        }
    }
}
