using BGHub.BE.Models;
using BGHub.BE.Repositories;
using BGHub.Models;

namespace BGHub.BE.Services
{
    public interface IEventService
    {
        public IEnumerable<Event> FindAllEvents();
        public Event? FindEventById(int id);
    }
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public IEnumerable<Event> FindAllEvents()
        {
            return _eventRepository.FindAllEvents();
        }
        public Event? FindEventById(int id)
        {
            return _eventRepository.FindEventById(id);
        }
    }
}
