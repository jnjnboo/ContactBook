using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public int ContactId { get; set; }
        public DateTime Date { get; set; }
        public int? EventTypeId { get; set; }

        public Contact Contact { get; set; }
        public EventType EventType { get; set; }
    }
}
