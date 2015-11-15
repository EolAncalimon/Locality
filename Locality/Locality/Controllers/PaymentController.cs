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
using Locality.Domain.Users;
using Microsoft.SqlServer.Server;

namespace Locality.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IEventService _eventService; 

        public PaymentController(IPaymentService paymentService, IUserService userService, IEventService eventService)
        {
            _paymentService = paymentService;
            _userService = userService;
            _eventService = eventService;
        }

        public async Task<HttpResponseMessage> PaymentWithToken(string fbAccessCode, Guid eventId, string token)
        {
            var user = await _userService.GetUserWithToken(fbAccessCode);
            var ev = await _eventService.GetEvent(eventId);

            if (user == null) return Request.CreateResponse(HttpStatusCode.Forbidden);

            var ticket = await _paymentService.BuyTicketWithToken(token, null, user);

            user.CustomerId = ticket.User.CustomerId;

            await _userService.UpdateUser(user);

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
