using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Locality.Domain.Payments;
using Locality.Domain.Users;
using Microsoft.SqlServer.Server;

namespace Locality.Controllers
{
    public class PaymentController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;

        public PaymentController(IPaymentService paymentService, IUserService userService)
        {
            _paymentService = paymentService;
            _userService = userService;
        }

        //public async Task<HttpResponseMessage> PaymentWithToken(string fbAccessCode, string eventId, string token)
        //{
        //    var user = await _userService.GetUserWithToken(fbAccessCode);

        //    if (user == null) return Request.CreateResponse(HttpStatusCode.Forbidden);

        //    var ticket = await _paymentService.BuyTicketWithToken(token, null, user);
        //}
    }
}
