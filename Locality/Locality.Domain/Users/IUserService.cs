using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locality.Data.Entities.Users;

namespace Locality.Domain.Users
{
    public interface IUserService
    {
        Task<User> GetUser(string facebookId);
        Task<User> GetUserWithToken(string facebookToken);
        Task<User> CreateUser(User entity);

        Task<User> UpdateUser(User entity);


    }
}
