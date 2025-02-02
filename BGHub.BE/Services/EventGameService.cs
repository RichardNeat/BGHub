using BGHub.BE.Models;
using BGHub.BE.Repositories;
using BGHub.Models;

namespace BGHub.BE.Services
{
    public interface IEventGameService
    {
        public EventGame InsertGameToEvent(EventGameDTO eventGame);
    }
    public class EventGameService : IEventGameService
    {
        private readonly IEventGameRepository _eventRepository;
        public EventGameService(IEventGameRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public EventGame InsertGameToEvent(EventGameDTO eventGame)
        {
            return _eventRepository.InsertGameToEvent(eventGame);
        }
    }
}
