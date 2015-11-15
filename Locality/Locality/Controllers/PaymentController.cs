using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Locality.Domain.Events;
using Locality.Domain.Payments;
using Locality.Domain.Tickets;
using Locality.Domain.Users;
using Microsoft.SqlServer.Server;

namespace Locality.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly ITicketService _ticketService;

        public PaymentController(IPaymentService paymentService, IUserService userService, IEventService eventService, ITicketService ticketService)
        {
            _paymentService = paymentService;
            _userService = userService;
            _eventService = eventService;
            _ticketService = ticketService;
        }

        public async Task<HttpResponseMessage> PaymentWithToken(string authToken, Guid eventId, string paymentToken)
        {
            var user = await _userService.GetUserWithToken(authToken);
            var ev = await _eventService.GetEvent(eventId);

            if (user == null) return Request.CreateResponse(HttpStatusCode.Forbidden);

            var ticket = await _paymentService.BuyTicketWithToken(paymentToken, ev, user);

            user.CustomerId = ticket.CustomerId;

            await _userService.UpdateUser(user);

            _ticketService.AddTicket(ticket);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        public async Task<HttpResponseMessage> PaymentWithCustomerId(string authToken, Guid eventId)
        {
            var user = await _userService.GetUserWithToken(authToken);
            var ev = await _eventService.GetEvent(eventId);

            if (user == null) return Request.CreateResponse(HttpStatusCode.Forbidden);

            var ticket = await _paymentService.BuyTicketWithCustomer(ev, user);

            await _ticketService.AddTicket(ticket);

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
