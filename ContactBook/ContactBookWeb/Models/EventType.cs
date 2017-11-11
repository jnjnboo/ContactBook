using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
