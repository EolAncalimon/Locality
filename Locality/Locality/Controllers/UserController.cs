using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Locality.Data.Entities.Users;
using Locality.Domain.Users;

namespace Locality.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<HttpResponseMessage> GetUser(string facebookId)
        {
            var user = await _userService.GetUser(facebookId);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        public async Task<HttpResponseMessage> CreateUser(string facebookId, string firstName, string lastName)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FacebookId = facebookId,
                FirstName = firstName,
                LastName = lastName
            };

            var createdUser = await _userService.CreateUser(newUser);

            return Request.CreateResponse(HttpStatusCode.OK, createdUser);
        }
    }
}
