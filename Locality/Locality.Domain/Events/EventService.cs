using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Xml;
using Locality.Data.Repositories;

namespace Locality.Domain.Events
{
    public class EventService : IEventService
    {
        private readonly IRepository<Data.Entities.Events.Events> _repository;

        public EventService(IRepository<Data.Entities.Events.Events> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Data.Entities.Events.Events> GetAllEvents()
        {
            var todaysDate = Convert.ToDateTime(DateTime.Now).Date;
            return _repository.List(ev => DbFunctions.TruncateTime(ev.Start) == todaysDate);
        }

        public async Task<Data.Entities.Events.Events> GetEvent(Guid id)
        {
            return await _repository.Get(ev => ev.Id == id);
        }
    }
}