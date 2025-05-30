﻿using BGHub.BE.Repositories;
using BGHub.Models;

namespace BGHub.BE.Services
{
    public interface IEventGameService
    {
        public IEnumerable<EventGame> FindAllEventGames();
        public EventGame InsertGameToEvent(EventGameDTO eventGame);
        public void RemoveGameFromEvent(int id);
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
        public void RemoveGameFromEvent(int id)
        {
            _eventRepository.RemoveGameFromEvent(id);
        }
        public IEnumerable<EventGame> FindAllEventGames()
        {
            return _eventRepository.FindAllEventGames();
        }
    }
}
