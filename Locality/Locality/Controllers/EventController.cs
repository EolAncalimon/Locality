using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Locality.Domain.Events;

namespace Locality.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public HttpResponseMessage Events()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _eventService.GetAllEvents());
        }
    }
}
