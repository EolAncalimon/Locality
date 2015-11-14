using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locality.Data.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FacebookId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
