using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Locality.Domain.Tickets;
using Locality.Domain.Users;

namespace Locality.Controllers
{
    public class TicketController : ApiController
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public TicketController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Tickets(string authToken)
        {
            var user = await _userService.GetUserWithToken(authToken);

            return user == null ? Request.CreateResponse(HttpStatusCode.Forbidden) : Request.CreateResponse(HttpStatusCode.OK, _ticketService.GetTicketsForUser(user.Id));
        }
    }
}
