using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locality.Domain.Events
{
    public interface IEventService
    {
        IEnumerable<Data.Entities.Events.Events> GetAllEvents();

        Task<Data.Entities.Events.Events> GetEvent(Guid id);
    }
}
