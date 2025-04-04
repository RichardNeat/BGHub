﻿namespace BGHub.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LocationLink { get; set; }
        public List<EventGame> Inventory { get; set; }
    }
}
