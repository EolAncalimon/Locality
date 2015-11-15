using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Facebook;
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

        public async Task<HttpResponseMessage> Login(string authToken)
        {
            var fb = new FacebookClient(authToken);
            fb.AppSecret = Environment.GetEnvironmentVariable("FacebookSecret");
            dynamic result = await fb.GetTaskAsync("me");
            var existingUser = (User)await _userService.GetUser(result.Id);
            if (existingUser == null)
            {
                var newUser = await _userService.CreateUser(new User
                {
                    Id = Guid.NewGuid(),
                    FacebookId = result.id.ToString(),
                    FacebookToken = authToken,
                    Name = result.name.ToString(),
                    UpdatedAt = DateTime.Now
                });
                
                return Request.CreateResponse(HttpStatusCode.OK, newUser);
            }

            existingUser.Name = result.name.ToString();
            existingUser.FacebookToken = authToken;
            existingUser.UpdatedAt = DateTime.Now;

            var updatedUser = await _userService.UpdateUser(existingUser);

            return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
        }

        public async Task<HttpResponseMessage> GetUser(string facebookId)
        {
            var user = await _userService.GetUser(facebookId);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        public async Task<HttpResponseMessage> GetUserWithToken(string facebookToken)
        {
            var user = await _userService.GetUser(facebookToken);

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
