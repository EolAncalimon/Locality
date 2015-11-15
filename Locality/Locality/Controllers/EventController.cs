using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Locality.Domain.Events;
using Locality.Domain.Tickets;
using Locality.Domain.Users;

namespace Locality.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;

        public EventController(IEventService eventService, IUserService userService, ITicketService ticketService)
        {
            _eventService = eventService;
            _userService = userService;
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Events(string authToken)
        {
            var user = await _userService.GetUserWithToken(authToken);
            var tickets = _ticketService.GetTicketsForUser(user.Id);
            return Request.CreateResponse(HttpStatusCode.OK, _eventService.GetAllEvents().Select(e =>
            {
                e.HasTicket = tickets.Any(t => t.EventId == e.Id);
                return e;
            }));
        }
    }
}
