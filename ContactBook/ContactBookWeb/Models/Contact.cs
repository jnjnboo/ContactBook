using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Address = new HashSet<Address>();
            Email = new HashSet<Email>();
            Event = new HashSet<Event>();
            Phone = new HashSet<Phone>();
            Website = new HashSet<Website>();
        }

        public int ContactId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PreferredName { get; set; }
        public string PreviousNames { get; set; }
        public string Notes { get; set; }
        public string Relationship { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public ICollection<Address> Address { get; set; }
        public ICollection<Email> Email { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<Phone> Phone { get; set; }
        public ICollection<Website> Website { get; set; }
    }
}
