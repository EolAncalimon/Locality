using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locality.Data.Entities.Users;
using Locality.Data.Repositories;

namespace Locality.Domain.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUser(string facebookId)
        {
            return await _repository.Get(u => u.FacebookId == facebookId);
        }

        public async Task<User> GetUserWithToken(string facebookToken)
        {
            return await _repository.Get(u => u.FacebookToken == facebookToken);
        }

        public async Task<User> CreateUser(User entity)
        {
            _repository.Add(entity);
           await  _repository.SaveChangesAsync();

            return await _repository.Get(u => u.FacebookId == entity.FacebookId);
        }

        public async Task<User> UpdateUser(User entity)
        {
            _repository.Update(entity);

            await _repository.SaveChangesAsync();

            return await _repository.Get(u => u.FacebookToken == entity.FacebookToken);
        }
    }
}
